using SwimmingPool.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SwimmingPool
{
    public partial class UserControlSendEmail : UserControl
    {
        private string[] fileNames;
        private Dictionary<string, Object> data;

        public UserControlSendEmail(Dictionary<string, Object> data) : this()
        {
            this.data = data;
        }
        public UserControlSendEmail()
        {
            InitializeComponent();
        }

        private void UserControlSendEmail_Load(object sender, EventArgs e)
        {
            var db = new DatabaseContext();
            var id = data["id"].ToString();
            var account = db.Members.SingleOrDefault(acc => acc.MemberID == id);
            textBoxTo.Text = account.Email;
        }
        private void buttonAttachFiles_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog.FileNames;
            }
            foreach(string fileName in fileNames)
            {
                labelFileNames.Text += fileName + " ";
            }
        }

        private void buttonSendEmail_Click(object sender, EventArgs e)
        {
            var to = textBoxTo.Text;
            var subject = richTextBoxSubject.Text;
            var content = richTextBoxContent.Text;

            if (MailHelper.Send(to, subject, content, true, fileNames))
            {
                var db = new DatabaseContext();
                Mail mail = new Mail();
                mail.MailTo = to;
                mail.Subject = subject;
                mail.MailBody = content;
                mail.Status = "Success";
                db.Mails.Add(mail);
                if(db.SaveChanges() > 0)
                {
                    MessageBox.Show("Sent successfully! ");
                }
                   
            }
            else
            {
                var db = new DatabaseContext();
                Mail mail = new Mail();
                mail.MailTo = to;
                mail.Subject = subject;
                mail.MailBody = content;
                mail.Status = "Failed";
                db.Mails.Add(mail);
                if(db.SaveChanges() > 0)
                {
                    MessageBox.Show("Fail to send! ");
                }
                
            }
        }
    }
}
