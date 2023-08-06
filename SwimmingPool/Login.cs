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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;
            var account = db.Members.SingleOrDefault(mem => mem.MemberID == username);
            if(account != null)
            {
                if(account.Password == password)
                {
                    var data = new Dictionary<string, Object>();
                    data.Add("username", account);
                    var mainWindow = new MainWindow(data);
                    MessageBox.Show("Login sucessfully");
                    mainWindow.Show();
                    Hide();
                } else
                {
                    MessageBox.Show("Failed to login!");
                }
            } else
            {
                MessageBox.Show("Failed to login!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
