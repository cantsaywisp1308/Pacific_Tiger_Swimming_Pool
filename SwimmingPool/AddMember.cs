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
    public partial class AddMember : Form
    {
        private Dictionary<string, Object> data;

        public AddMember(Dictionary<string, Object> data) : this()
        {
            this.data = data;
        }
        public AddMember()
        {
            InitializeComponent();
        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var memberships = db.Memberships.ToList();
            comboBoxMembership.DataSource = memberships;
            comboBoxMembership.DisplayMember = "MembershipName";
            comboBoxMembership.ValueMember = "MembershipType";
        }

        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var fullName = "";
            var id = "";
            var random = new Random();
            var randomString = random.Next(10000).ToString();
            if(textBoxMiddleName.Text == "")
            {
                fullName = textBoxFirstName.Text + " " + textBoxLastName.Text;
                id += textBoxFirstName.Text + textBoxLastName.Text +"#"+ randomString;
            } else
            {
                fullName = textBoxFirstName + " " + textBoxMiddleName.Text + " " + textBoxLastName.Text; 
                id += textBoxFirstName.Text + textBoxMiddleName.Text+ textBoxLastName.Text + "#" + randomString;
            }
            var numberOfEntries = 1;
            var expiredDate = DateTime.Now;
            var member1 = new Member();
            if(int.Parse(comboBoxMembership.SelectedValue.ToString()) == 5)
            {
                numberOfEntries = 10;
                expiredDate = DateTime.MaxValue.AddYears(-300);
            }

            var member = new Member
            {
                MemberID = id,
                FirstName = textBoxFirstName.Text,
                MiddleName = textBoxMiddleName.Text,
                LastName = textBoxLastName.Text,
                FullName = fullName,
                Phone = textBoxPhone.Text,
                Email = textBoxEmail.Text,
                InitialDate = DateTime.Today,
                MembershipType = int.Parse(comboBoxMembership.SelectedValue.ToString()),
                NumberOfEntries = numberOfEntries,
                Notes = richTextBoxNotes.Text,
                Password = "1234567890",
                ExpiredDate = expiredDate,
                Status = false
            };
            db.Members.Add(member);
            if(db.SaveChanges() > 0)
            {
                MessageBox.Show("Added a new member!");
                Hide();
                var mainWindow = new MainWindow();
                mainWindow.Refresh();
            } else
            {
                MessageBox.Show("Failed to add a new member");
            }
        }

        private void buttonCancelAddMember_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
