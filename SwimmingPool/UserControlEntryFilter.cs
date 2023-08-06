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
    public partial class UserControlEntryFilter : UserControl
    {
        public UserControlEntryFilter()
        {
            InitializeComponent();
        }

        private void UserControlEntryFiler_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            var db = new DatabaseContext();
            labelTotalEntries.Text = db.Entries.ToList().Count.ToString();
            dataGridViewEntries.DataSource = db.Entries.Select(entry => new
            {
                Entry_number = entry.Number,
                Member_ID = entry.MemberID,
                Member_Full_Name = entry.Member.FullName,
                Membership_Type = entry.Membership.MembershipName,
                Check_in_time = entry.checkIn
            }).ToList();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            var filterTimeFrom = dateTimePickerFrom.Value;
            var filterTimeTo = dateTimePickerTo.Value;
            var db = new DatabaseContext();
            dataGridViewEntries.DataSource = db.Entries.Where(en => en.checkIn >=filterTimeFrom && en.checkIn <=filterTimeTo)
                .Select(en => new
                {
                    Entry_number = en.Number,
                    Member_ID = en.MemberID,
                    Member_Full_Name = en.Member.FullName,
                    Membership_Type = en.Membership.MembershipName,
                    Check_in_time = en.checkIn
                }).ToList();
            var totalEntries = db.Entries.Where(en => en.checkIn >= filterTimeFrom && en.checkIn <= filterTimeTo).Count();
            labelTotalEntries.Text = totalEntries.ToString();
                
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            labelTotalEntries.Text = db.Entries.ToList().Count.ToString();
            dataGridViewEntries.DataSource = db.Entries.Select(entry => new
            {
                Entry_number = entry.Number,
                Member_ID = entry.MemberID,
                Member_Full_Name = entry.Member.FullName,
                Membership_Type = entry.Membership.MembershipName,
                Check_in_time = entry.checkIn
            }).ToList();
        }
    }

    
}
