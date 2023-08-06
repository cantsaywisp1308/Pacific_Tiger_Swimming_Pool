using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class UpdateMembership : Form
    {
        private Dictionary<string, Object> data;

        public UpdateMembership(Dictionary<string, Object> data) : this()
        {
            this.data = data;
        }
        public UpdateMembership()
        {
            InitializeComponent();
        }

        private void UpdateMembership_Load(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var membershipID = int.Parse(data["membershipID"].ToString());
            var membership = db.Memberships.SingleOrDefault(ms => ms.MembershipType == membershipID);
            textBoxMembershipName.Text = membership.MembershipName;
            textBoxMembershipPrice.Text = membership.Price.ToString();
            richTextBoxMembershipNotes.Text = membership.Notes;
        }

        private void buttonUpdateMembership_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DatabaseContext();
                var membershipID = int.Parse(data["membershipID"].ToString());
                var membership = db.Memberships.SingleOrDefault(ms => ms.MembershipType == membershipID);
                membership.MembershipName = textBoxMembershipName.Text;
                membership.Price = int.Parse(textBoxMembershipPrice.Text);
                membership.Notes = richTextBoxMembershipNotes.Text;
                db.Entry(membership).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Updated membership successfully!!!");
                    Hide();
                }
                else
                {
                    MessageBox.Show("Failed to update this membership!!!");
                }
            } catch (Exception ex)
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
