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
    public partial class Entries : Form
    {
        private Dictionary<string, Object> data;

        public Entries(Dictionary<string, Object> data) : this()
        {
            this.data = data;
        }
        public Entries()
        {
            InitializeComponent();
        }

        private void Entries_Load(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = data["id"].ToString();
            var account = db.Members.SingleOrDefault(acc => acc.MemberID == id);
            labelEntriesOdID.Text = "Entries by " + account.FullName;
            dataGridViewEntries.DataSource = db.Entries.Where(en => en.MemberID == id).Select(en => new
            {
                Check_in_number = en.Number,
                Member_ID = en.MemberID,
                Member_Full_Name = en.Member.FullName,
                Membership_Type = en.Membership.MembershipName,
                Check_in_time = en.checkIn
            }).ToList();
        }
    }
}
