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
    public partial class AddMembership : Form
    {
        public AddMembership()
        {
            InitializeComponent();
        }

        private void buttonAddMembership_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DatabaseContext();
                var membership = new Membership();
                membership.MembershipName = textBoxMembershipName.Text;
                membership.Price = int.Parse(textBoxMembershipPrice.Text);
                membership.Notes = richTextBoxMembershipNotes.Text;
                db.Memberships.Add(membership);
                if(db.SaveChanges() > 0)
                {
                    MessageBox.Show("Added a new membership!!!");
                    Hide();
                    var mainWindow = new MainWindow();
                    mainWindow.Refresh();
                } else
                {
                    MessageBox.Show("Failed to add a new membership!!!");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
