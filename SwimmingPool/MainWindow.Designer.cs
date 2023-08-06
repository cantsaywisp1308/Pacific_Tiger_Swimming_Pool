namespace SwimmingPool
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memberManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewalsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSemestaeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMembershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.sendAnnouncementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem,
            this.welcomeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memberManagerToolStripMenuItem,
            this.filterEntriesToolStripMenuItem,
            this.renewalsReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // memberManagerToolStripMenuItem
            // 
            this.memberManagerToolStripMenuItem.Name = "memberManagerToolStripMenuItem";
            this.memberManagerToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.memberManagerToolStripMenuItem.Text = "Member Manager";
            this.memberManagerToolStripMenuItem.Click += new System.EventHandler(this.memberManagerToolStripMenuItem_Click);
            // 
            // filterEntriesToolStripMenuItem
            // 
            this.filterEntriesToolStripMenuItem.Name = "filterEntriesToolStripMenuItem";
            this.filterEntriesToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.filterEntriesToolStripMenuItem.Text = "Filter Entries";
            this.filterEntriesToolStripMenuItem.Click += new System.EventHandler(this.filterEntriesToolStripMenuItem_Click);
            // 
            // renewalsReportToolStripMenuItem
            // 
            this.renewalsReportToolStripMenuItem.Name = "renewalsReportToolStripMenuItem";
            this.renewalsReportToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.renewalsReportToolStripMenuItem.Text = "Renewals Report";
            this.renewalsReportToolStripMenuItem.Click += new System.EventHandler(this.renewalsReportToolStripMenuItem_Click);
            // 
            // welcomeToolStripMenuItem
            // 
            this.welcomeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeSemestaeDateToolStripMenuItem,
            this.exportFileToolStripMenuItem,
            this.editMembershipToolStripMenuItem,
            this.contactToolStripMenuItem,
            this.sendAnnouncementsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.welcomeToolStripMenuItem.Name = "welcomeToolStripMenuItem";
            this.welcomeToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.welcomeToolStripMenuItem.Text = "Admin";
            // 
            // changeSemestaeDateToolStripMenuItem
            // 
            this.changeSemestaeDateToolStripMenuItem.Name = "changeSemestaeDateToolStripMenuItem";
            this.changeSemestaeDateToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.changeSemestaeDateToolStripMenuItem.Text = "Change Semester Date";
            this.changeSemestaeDateToolStripMenuItem.Click += new System.EventHandler(this.changeSemestaeDateToolStripMenuItem_Click);
            // 
            // exportFileToolStripMenuItem
            // 
            this.exportFileToolStripMenuItem.Name = "exportFileToolStripMenuItem";
            this.exportFileToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.exportFileToolStripMenuItem.Text = "Export Member File";
            this.exportFileToolStripMenuItem.Click += new System.EventHandler(this.exportFileToolStripMenuItem_Click);
            // 
            // editMembershipToolStripMenuItem
            // 
            this.editMembershipToolStripMenuItem.Name = "editMembershipToolStripMenuItem";
            this.editMembershipToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.editMembershipToolStripMenuItem.Text = "Edit Membership";
            this.editMembershipToolStripMenuItem.Click += new System.EventHandler(this.editMembershipToolStripMenuItem_Click);
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.contactToolStripMenuItem.Text = "Contact";
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.contactToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelMain, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 483);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 66);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cambria", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(602, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chris Kjeldsen Swimming Pool";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(3, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(986, 405);
            this.panelMain.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // sendAnnouncementsToolStripMenuItem
            // 
            this.sendAnnouncementsToolStripMenuItem.Name = "sendAnnouncementsToolStripMenuItem";
            this.sendAnnouncementsToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.sendAnnouncementsToolStripMenuItem.Text = "Send Announcements";
            this.sendAnnouncementsToolStripMenuItem.Click += new System.EventHandler(this.sendAnnouncementsToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Chris Kjeldsen Swimming Pool Member Manager";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem welcomeToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem memberManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewalsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSemestaeDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFileToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem editMembershipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendAnnouncementsToolStripMenuItem;
    }
}

