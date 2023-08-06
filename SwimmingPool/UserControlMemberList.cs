using SwimmingPool.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class UserControlMemberList : UserControl
    {
        private Dictionary<string, Object> data;
        private string[] fileNames;

        public UserControlMemberList(Dictionary<string, Object> data) : this()
        {
            this.data = data;
        }
        public UserControlMemberList()
        {
            InitializeComponent();
        }

        private void UserControlMemberList_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            var db = new DatabaseContext();
            dataGridViewMemberList.DataSource = db.Members.Select(mem => new
            {
                ID = mem.MemberID,
                First_Name = mem.FirstName,
                Middle_Name = mem.MiddleName,
                Last_Name = mem.LastName,
                Full_Name = mem.FullName,
                Date_Of_initial = mem.InitialDate,
                Phone = mem.Phone,
                Email = mem.Email,
                Number_Of_Entries = mem.NumberOfEntries,
                Membership_Type = mem.Membership.MembershipName,
                Expired_Date = mem.ExpiredDate,
                Notes = mem.Notes,
                In_Water = mem.Status
            }).ToList();
            labelIn_water.Text = db.Members.Where(acc => acc.Status == true).Count().ToString();
            comboBoxMembership.DataSource = db.Memberships.ToList();
            comboBoxMembership.DisplayMember = "MembershipName";
            comboBoxMembership.ValueMember = "MembershipType";

            foreach(var mem in db.Members)
            {
                  if(DateTime.Today.AddDays(7) == (mem.ExpiredDate) && mem.Email != null)
                  {
                    var subject = "Your account is about to expire!";
                    var body = "Dear " + mem.FullName + ", \n";
                    body += "Your date of expiration will be " + mem.ExpiredDate.ToString() + " You can extend your account at the swimming pool\n";
                    body += "Have a nice day, \n";
                    body += "Thank you. \n";
                    if(MailHelper.Send(mem.Email, subject,body))
                    {

                    }
                  }
            }
        }

        private void buttonAddNewMember_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var addMember = new AddMember();
            addMember.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            var db = new DatabaseContext();
            dataGridViewMemberList.DataSource = db.Members.Select(mem => new
            {
                ID = mem.MemberID,
                First_Name = mem.FirstName,
                Middle_Name = mem.MiddleName,
                Last_Name = mem.LastName,
                Full_Name = mem.FullName,
                Date_Of_initial = mem.InitialDate,
                Phone = mem.Phone,
                Email = mem.Email,
                Number_Of_Entries = mem.NumberOfEntries,
                Membership_Type = mem.Membership.MembershipName,
                Expired_Date = mem.ExpiredDate,
                Notes = mem.Notes,
                In_Water = mem.Status
            }).ToList();
        }

        private void buttonDeleteMember_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
            var account = db.Members.SingleOrDefault(acc =>acc.MemberID == id);
            var entries = db.Entries.Where(ent => ent.MemberID == id).ToList();
            var renewals = db.Renewals.Where(ren=>ren.MemberID == id).ToList();
            string message = "Are you sure want to delete this member ?";
            string title = "Delete member";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, button);
            if(result == DialogResult.Yes)
            {
                foreach(var entry in entries)
                {
                    db.Entries.Remove(entry);
                }
                foreach(var renewal in renewals)
                {
                    db.Renewals.Remove(renewal);
                }
                db.Members.Remove(account);

                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Deleted successfully!!!");

                    Panel panelMain = (Panel)Parent;
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(new UserControlMemberList());
                }
                else
                {
                    MessageBox.Show("Falied to delete this member");
                }
            } else
            {

            }
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
            var data = new Dictionary<string, object>();
            data.Add("id", id);
            var updateProfile = new UpdateProfile(data);
            updateProfile.Show();
        }

        private void comboBoxMembership_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var membershipType = int.Parse(comboBoxMembership.SelectedValue.ToString());
            dataGridViewMemberList.DataSource = db.Members.Where(acc => acc.MembershipType == membershipType).Select(acc => new
            {
                ID = acc.MemberID,
                First_Name = acc.FirstName,
                Middle_Name = acc.MiddleName,
                Last_Name = acc.LastName,
                Full_Name = acc.FullName,
                Date_Of_initial = acc.InitialDate,
                Phone = acc.Phone,
                Email = acc.Email,
                Number_Of_Entries = acc.NumberOfEntries,
                Membership_Type = acc.Membership.MembershipName,
                Expired_Date = acc.ExpiredDate,
                Notes = acc.Notes,
                In_Water = acc.Status
            }).ToList();
        }

        private void textBoxNameSearch_TextChanged(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var str = textBoxNameSearch.Text;
            dataGridViewMemberList.DataSource = db.Members.Where(acc => acc.FullName.Contains(str)).Select(acc => new
            {
                ID = acc.MemberID,
                First_Name = acc.FirstName,
                Middle_Name = acc.MiddleName,
                Last_Name = acc.LastName,
                Full_Name = acc.FullName,
                Date_Of_initial = acc.InitialDate,
                Phone = acc.Phone,
                Email = acc.Email,
                Number_Of_Entries = acc.NumberOfEntries,
                Membership_Type = acc.Membership.MembershipName,
                Expired_Date = acc.ExpiredDate,
                Notes = acc.Notes,
                In_Water = acc.Status
            }).ToList();
        }

        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
            Entry entry = new Entry();
            var account = db.Members.SingleOrDefault(acc => acc.MemberID == id);

            if(account.MembershipType == 5)  //If membership is 10-punch-pass
            {
                if (account.NumberOfEntries > 0)
                {
                    entry.MemberID = id;
                    entry.MembershipType = account.MembershipType;
                    entry.checkIn = DateTime.Now;
                    db.Entries.Add(entry);
                    account.NumberOfEntries -=1;
                    account.Status = true;
                    if(db.SaveChanges() >0)
                    {
                        MessageBox.Show("Check-in successfully !!!");
                    } else
                    {
                        MessageBox.Show("Failed to check-in");
                    }           
                }
                else
                {
                    MessageBox.Show("This member expired");
                }

            } else if(account.MembershipType == 6) // if membership is daily
            {
                account.Status = true;
                Renewal renewal = new Renewal();
                renewal.MemberID = account.MemberID;
                renewal.MembershipType = account.MembershipType; 
                renewal.Price = account.Membership.Price;
                renewal.DateOfRenewal = DateTime.Today;
                renewal.DateOfExpiration = DateTime.Today;
                db.Renewals.Add(renewal);
                db.SaveChanges();
            } else
            {
                if(account.ExpiredDate >= DateTime.Today)
                {
                    entry.MemberID = id;
                    entry.MembershipType = account.MembershipType;
                    entry.checkIn = DateTime.Now;
                    account.NumberOfEntries -=1;
                    db.Entries.Add(entry);
                    account.Status = true;
                    if (db.SaveChanges() > 0)
                    {
                        MessageBox.Show("Check-in successfully !!!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to check-in !!!");
                    }
                }
                else
                {
                    MessageBox.Show("This member expired");
                }
            }
            Panel panelMain = (Panel)Parent;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new UserControlMemberList());
        }

        private void buttonSeeEntries_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
            var data = new Dictionary<string, object>();
            data.Add("id", id);
            var entries = new Entries(data);
            entries.Show();
        }

        private void buttonSendIndivisualEmail_Click(object sender, EventArgs e)
        {
            var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
            var data = new Dictionary<string, object>();
            data.Add("id", id);
            var userControlSendEmail = new UserControlSendEmail(data);
            Panel panelMain = (Panel)Parent;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlSendEmail);
        }

        private void buttonRenew_Click(object sender, EventArgs e)
        {
            var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
            var db = new DatabaseContext();
            var account = db.Members.SingleOrDefault(acc => acc.MemberID == id);
            var lastDate = Properties.Resources.lastDateSemester;
            Renewal renewal = new Renewal();
            renewal.MemberID = id;
            renewal.MembershipType = account.MembershipType;
            renewal.Price = account.Membership.Price;
            renewal.DateOfRenewal = DateTime.Today;
            if(account.MembershipType==1 || account.MembershipType == 2)
            {
                renewal.DateOfExpiration = DateTime.ParseExact(lastDate,"M/d/yyyy",CultureInfo.InvariantCulture);
                account.ExpiredDate = renewal.DateOfExpiration;
            } else if(account.MembershipType == 3)
            {
                renewal.DateOfExpiration = account.ExpiredDate.Value.AddMonths(1);
                account.ExpiredDate = renewal.DateOfExpiration;
            } else if (account.MembershipType == 4)
            {
                renewal.DateOfExpiration = account.ExpiredDate.Value.AddMonths(6);
                account.ExpiredDate = renewal.DateOfExpiration;
            } else if (account.MembershipType == 5)
            {
                account.NumberOfEntries = 10;
                renewal.DateOfExpiration= account.ExpiredDate.Value.AddMonths(6);
                account.ExpiredDate = renewal.DateOfExpiration;
            } else if(account.MembershipType == 7)
            {
                renewal.DateOfExpiration = account.ExpiredDate.Value.AddYears(1);
                account.ExpiredDate = renewal.DateOfExpiration;
            }
            db.Renewals.Add(renewal);
            if(db.SaveChanges() > 0)
            {
                MessageBox.Show("Renewed successfully!!!");
            } else
            {
                MessageBox.Show("Failed to renew!!!");
            }
        }

        private void buttonSeeNotes_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
            var account = db.Members.SingleOrDefault(mem => mem.MemberID == id);
            richTextBoxNotes.Text = account.Notes;
        }

        private void dataGridViewMemberList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewMemberList.Rows)
            {
                if (Convert.ToBoolean(row.Cells[12].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void buttonEndShift_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            foreach(var account in db.Members.Where(acc=> acc.Status == true))
            {
                account.Status = false;
            }
            if(db.SaveChanges() > 0)
            {
                MessageBox.Show("Shift ended !");
                Panel panelMain = (Panel)Parent;
                panelMain.Controls.Clear();
                panelMain.Controls.Add(new UserControlMemberList());
            }
        }

        private void checkBoxIn_water_CheckedChanged(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            if(checkBoxIn_water.Checked == true)
            {
                dataGridViewMemberList.DataSource = db.Members.Where(acc => acc.Status == true).Select(acc => new
                {
                    ID = acc.MemberID,
                    First_Name = acc.FirstName,
                    Middle_Name = acc.MiddleName,
                    Last_Name = acc.LastName,
                    Full_Name = acc.FullName,
                    Date_Of_initial = acc.InitialDate,
                    Phone = acc.Phone,
                    Email = acc.Email,
                    Number_Of_Entries = acc.NumberOfEntries,
                    Membership_Type = acc.Membership.MembershipName,
                    Expired_Date = acc.ExpiredDate,
                    Notes = acc.Notes,
                    In_Water = acc.Status
                }).ToList();
            } else
            {
                dataGridViewMemberList.DataSource = db.Members.Select(acc => new
                {
                    ID = acc.MemberID,
                    First_Name = acc.FirstName,
                    Middle_Name = acc.MiddleName,
                    Last_Name = acc.LastName,
                    Full_Name = acc.FullName,
                    Date_Of_initial = acc.InitialDate,
                    Phone = acc.Phone,
                    Email = acc.Email,
                    Number_Of_Entries = acc.NumberOfEntries,
                    Membership_Type = acc.Membership.MembershipName,
                    Expired_Date = acc.ExpiredDate,
                    Notes = acc.Notes,
                    In_Water = acc.Status
                }).ToList();
            }
           
        }

        private void buttonSetToNever_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DatabaseContext();
                var id = dataGridViewMemberList.CurrentRow.Cells[0].Value.ToString();
                var account = db.Members.SingleOrDefault(acc => acc.MemberID == id);
                account.ExpiredDate = new DateTime(2100, 12, 31);
                account.MembershipType = int.Parse(comboBoxMembership.SelectedValue.ToString());
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Set expired date to 12/31/2100 !!!");
                    dataGridViewMemberList.DataSource = db.Members.Select(mem => new
                    {
                        ID = mem.MemberID,
                        First_Name = mem.FirstName,
                        Middle_Name = mem.MiddleName,
                        Last_Name = mem.LastName,
                        Full_Name = mem.FullName,
                        Date_Of_initial = mem.InitialDate,
                        Phone = mem.Phone,
                        Email = mem.Email,
                        Number_Of_Entries = mem.NumberOfEntries,
                        Membership_Type = mem.Membership.MembershipName,
                        Expired_Date = mem.ExpiredDate,
                        Notes = mem.Notes,
                        In_Water = mem.Status
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Failed to set expired date!!!");
                }
            }
            catch
            {
                MessageBox.Show("Failed to set expired date!!!");
            }
        }
    }
}
