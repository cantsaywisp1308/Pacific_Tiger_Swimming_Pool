using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class MainWindow : Form
    {
        private Dictionary<string, Object> data;

        public MainWindow(Dictionary<string, Object> data) : this()
        {
            this.data = data;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //var account = (Member)data["username"];
            //welcomeToolStripMenuItem.Text = "Welcome " + account.MemberID;
            var userControlMember = new UserControlMemberList(); 
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlMember);
        }

        private void filterEntriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userControlEntryFilter = new UserControlEntryFilter();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlEntryFilter);
        }

        private void memberManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userControlMember = new UserControlMemberList();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlMember);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void renewalsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userControlRenewal = new UserControlRenewal();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlRenewal);
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contact = new Contacts();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(contact);
        }

        private void changeSemestaeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userControlSetLastDate = new UserControlSetLastDateSemester();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlSetLastDate);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        struct DataParameter
        {
            public List<Member> MemberList;
            public string fileName { get; set; }
        }

        DataParameter _inputParameter;

        private void exportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv*", ValidateNames = true })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    DatabaseContext db = new DatabaseContext();
                    _inputParameter.MemberList = db.Members.ToList();
                    _inputParameter.fileName = sfd.FileName + ".csv";
                    backgroundWorker1.RunWorkerAsync(_inputParameter);
                }       
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Member> list = ((DataParameter)e.Argument).MemberList;
            string fileName = ((DataParameter)e.Argument).fileName;
            using(StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID, First_Name, Middle_Name, Last_Name, Full_Name, Date_Of_Birth, Phone, Email, Number_Of_Entries, Membership_Type, Expired_Date, Notes");
                foreach (Member member in list)
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        sb.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                            member.MemberID,member.FirstName,member.MiddleName,member.LastName,member.FullName,member.InitialDate,member.Phone,member.Email,member.NumberOfEntries,member.MembershipType,member.ExpiredDate,member.Notes));
                    }
                }
                sw.Write(sb.ToString());
            }
            
        }

        private void editMembershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userControlMembership = new UserControlMembership();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlMembership);
        }

        private void sendAnnouncementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userControlSendAnnounements = new UserControlSendAnnouncements();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControlSendAnnounements);
        }
    }
}
