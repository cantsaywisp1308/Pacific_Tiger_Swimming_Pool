using SwimmingPool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class UpdateProfile : Form
    {
        private Dictionary<string, Object> data;
        public UpdateProfile(Dictionary<string, Object> data) : this()
        {
            this.data = data;
        }
        public UpdateProfile()
        {
            InitializeComponent();
        }

        private void UpdateProfile_Load(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = data["id"].ToString();
            var account = db.Members.SingleOrDefault(acc => acc.MemberID == id);
            if(account.MembershipType == null)
            {
                account.MembershipType = 8;
            }
            textBoxFirstName.Text = account.FirstName;
            textBoxMiddleName.Text = account.MiddleName;    
            textBoxLastName.Text = account.LastName;
            textBoxPhone.Text = account.Phone;
            textBoxEmail.Text = account.Email;
            comboBoxMembership.DataSource = db.Memberships.ToList();
            comboBoxMembership.DisplayMember = "MembershipName";
            comboBoxMembership.ValueMember = "MembershipType";
            comboBoxMembership.SelectedValue  = (int)account.MembershipType;
            richTextBoxNotes.Text = account.Notes;
            if(account.ExpiredDate == null)
            {
                dateTimePickerExpiredDate.Value = DateTime.Now;
            } else
            {
                dateTimePickerExpiredDate.Value = (DateTime)account.ExpiredDate;
            }
            if(account.InitialDate == null)
            {
                account.InitialDate = DateTime.ParseExact("01/01/1900","MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            textBoxEntries.Text = account.NumberOfEntries.ToString();
        }

        private void buttonUpdateMember_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DatabaseContext();
                var id = data["id"].ToString();
                var account = db.Members.SingleOrDefault(acc => acc.MemberID == id);
                account.FirstName = textBoxFirstName.Text;
                account.MiddleName = textBoxMiddleName.Text;
                account.LastName = textBoxLastName.Text;
                account.Phone = textBoxPhone.Text;
                account.Email = textBoxEmail.Text;
                account.Notes = richTextBoxNotes.Text;
                account.ExpiredDate = dateTimePickerExpiredDate.Value;
                account.NumberOfEntries = int.Parse(textBoxEntries.Text);
                if(int.Parse(comboBoxMembership.SelectedValue.ToString()) == 1)
                {
                    account.ExpiredDate = DateTime.ParseExact(Resources.lastDateSemester, "M/d/yyyy", CultureInfo.InvariantCulture);
                }
                account.MembershipType = int.Parse(comboBoxMembership.SelectedValue.ToString());
                if (textBoxMiddleName.Text == "")
                {
                    account.FullName = textBoxFirstName.Text + " " + textBoxLastName.Text;
                }
                else
                {
                    account.FullName = textBoxFirstName.Text + " " + textBoxMiddleName.Text + " " + textBoxLastName.Text;
                }
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Updated Profile Successfully!!!");
                    Hide();
                }
                else
                {
                    MessageBox.Show("Failed to update!!!");
                }
            } catch
            {
                MessageBox.Show("There is an error in updating!!!");
            }
            
        }

        private void buttonCancelAddMember_Click(object sender, EventArgs e)
        {
            Hide();
        }


    }
}
