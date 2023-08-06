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
    public partial class UserControlRenewal : UserControl
    {
        public UserControlRenewal()
        {
            InitializeComponent();
        }

        private void UserControlRenewal_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            var db = new DatabaseContext();
            labelTotalRenewals.Text = db.Renewals.Count().ToString();
            labelTotalMoney.Text = db.Renewals.Sum(r=>r.Price).ToString();
            dataGridViewRenewals.DataSource = db.Renewals.Select(renewals => new
            {
                Renewal_Number = renewals.RenewalNumber,
                Member_ID = renewals.MemberID,
                Member_Full_Name = renewals.Member.FullName,
                Membership_Type = renewals.Membership.MembershipName,
                Membership_Price = renewals.Price,
                Date_Of_Renewal = renewals.DateOfRenewal,
                Date_Of_Expiration = renewals.DateOfExpiration
            }).ToList();
        }

        private void buttonRenewalFilter_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            dataGridViewRenewals.DataSource = db.Renewals.Where(re => re.DateOfRenewal >= dateTimePickerFrom.Value && re.DateOfRenewal <= dateTimePickerTo.Value)
                .Select(re => new
                {
                    Renewal_Number = re.RenewalNumber,
                    Member_ID = re.MemberID,
                    Member_Full_Name = re.Member.FullName,
                    Membership_Type = re.Membership.MembershipName,
                    Membership_Price = re.Price,
                    Date_Of_Renewal = re.DateOfRenewal,
                    Date_Of_Expiration = re.DateOfExpiration
                }).ToList();
            labelTotalRenewals.Text = db.Renewals.Where(re => re.DateOfRenewal >= dateTimePickerFrom.Value && re.DateOfRenewal <= dateTimePickerTo.Value).Count().ToString();
            labelTotalMoney.Text = db.Renewals.Where(re => re.DateOfRenewal >= dateTimePickerFrom.Value && re.DateOfRenewal <= dateTimePickerTo.Value).Sum(r => r.Price).ToString();
        }
    }
}
