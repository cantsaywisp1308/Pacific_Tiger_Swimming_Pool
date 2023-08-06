using SwimmingPool.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class UserControlSetLastDateSemester : UserControl
    {

        

        public UserControlSetLastDateSemester()
        {
            InitializeComponent();
        }

        private void buttonSetLastDate_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var lastDate = dateTimePickerLastDate.Value;
            var data = new Dictionary<string, object>();

            ChangeSemesterLastDate("lastDateSemester", lastDate.ToString("M/d/yyyy"));
            data.Add("lastDate", lastDate);

            foreach (var account in db.Members.Where(acc=> acc.MembershipType == 1))
            {
                account.ExpiredDate = lastDate;
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
            }
            if(db.SaveChanges() > 0)
            {
                MessageBox.Show("Set semester date successfully !");
            }
            var userControlMemberList = new UserControlMemberList(data);
            Panel panelMain = (Panel)Parent;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlMemberList);

        }

        private void UserControlSetLastDateSemester_Load(object sender, EventArgs e)
        {
            var lastDate = Resources.lastDateSemester;
            if(lastDate == null)
            {
                ChangeSemesterLastDate("lastDateSemester", DateTime.Today.ToString());
                dateTimePickerLastDate.Value = DateTime.ParseExact(Properties.Resources.lastDateSemester, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            } else
            {
                dateTimePickerLastDate.Value = DateTime.ParseExact(Resources.lastDateSemester, "M/d/yyyy", CultureInfo.InvariantCulture);
            }
            
        }

        private static void ChangeSemesterLastDate(string key, string value)
        {
            var resx = new List<DictionaryEntry>();
            using (var reader = new ResXResourceReader("C:\\Users\\duykh\\source\\repos\\SwimmingPool1\\SwimmingPool\\Properties\\Resources.resx"))
            {
                resx = reader.Cast<DictionaryEntry>().ToList();
                var existingResource = resx.Where(r => r.Key.ToString() == key).FirstOrDefault();
                if (existingResource.Key == null && existingResource.Value == null) // NEW!
                {
                    resx.Add(new DictionaryEntry() { Key = key, Value = value });
                }
                else // MODIFIED RESOURCE!
                {
                    var modifiedResx = new DictionaryEntry() { Key = existingResource.Key, Value = value };
                    resx.Remove(existingResource);  // REMOVING RESOURCE!
                    resx.Add(modifiedResx);  // AND THEN ADDING RESOURCE!
                }
            }
            using (var writer = new ResXResourceWriter("C:\\Users\\duykh\\source\\repos\\SwimmingPool1\\SwimmingPool\\Properties\\Resources.resx"))
            {
                resx.ForEach(r =>
                {
                    // Again Adding all resource to generate with final items
                    writer.AddResource(r.Key.ToString(), r.Value.ToString());
                });
                writer.Generate();
            }
        }
    }
}
