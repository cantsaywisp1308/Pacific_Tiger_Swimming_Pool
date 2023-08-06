using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class UserControlMembership : UserControl
    {
        public UserControlMembership()
        {
            InitializeComponent();
        }

        private void UserControlMembership_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            var db = new DatabaseContext();
            dataGridViewMembership.DataSource = db.Memberships.Select(membership => new
            {
                Membership_Type = membership.MembershipType,
                Membership_Name = membership.MembershipName,
                Membership_Price = membership.Price,
                Membership_Notes = membership.Notes
            }).ToList();
        }

        private void buttonAddMembership_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var addMembership = new AddMembership();
            addMembership.Show();
        }

        private void buttonEditMembership_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var membershipID = dataGridViewMembership.CurrentRow.Cells[0].Value;
            var data = new Dictionary<string, object>();
            data.Add("membershipID", membershipID);
            var updateMembership = new UpdateMembership(data);
            updateMembership.Show();
        }

        private void buttonDeleteMembership_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DatabaseContext();
                var membershipID = int.Parse(dataGridViewMembership.CurrentRow.Cells[0].Value.ToString());
                var membership = db.Memberships.SingleOrDefault(ms => ms.MembershipType == membershipID);
                string message = "Are you sure want to delete this membership ?";
                string title = "Delete member";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, button);
                if (result == DialogResult.Yes)
                {
                    db.Memberships.Remove(membership);
                    if (db.SaveChanges() > 0)
                    {
                        MessageBox.Show("Successfully Deleted membership!!!");
                        Panel panelMain = (Panel)Parent;
                        panelMain.Controls.Clear();
                        var userControlMembership = new UserControlMembership();
                        panelMain.Controls.Add(userControlMembership);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete this membership");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Cannot delete this membership because there are members that are still under this membership!!!");
            }
            
        }
    }
}
