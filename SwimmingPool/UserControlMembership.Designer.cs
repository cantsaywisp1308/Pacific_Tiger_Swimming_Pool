namespace SwimmingPool
{
    partial class UserControlMembership
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteMembership = new System.Windows.Forms.Button();
            this.buttonEditMembership = new System.Windows.Forms.Button();
            this.buttonAddMembership = new System.Windows.Forms.Button();
            this.dataGridViewMembership = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembership)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewMembership, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1112, 534);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 127);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDeleteMembership);
            this.groupBox1.Controls.Add(this.buttonEditMembership);
            this.groupBox1.Controls.Add(this.buttonAddMembership);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Membership Tasks";
            // 
            // buttonDeleteMembership
            // 
            this.buttonDeleteMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteMembership.Location = new System.Drawing.Point(6, 101);
            this.buttonDeleteMembership.Name = "buttonDeleteMembership";
            this.buttonDeleteMembership.Size = new System.Drawing.Size(300, 33);
            this.buttonDeleteMembership.TabIndex = 2;
            this.buttonDeleteMembership.Text = "Delete membership";
            this.buttonDeleteMembership.UseVisualStyleBackColor = true;
            this.buttonDeleteMembership.Click += new System.EventHandler(this.buttonDeleteMembership_Click);
            // 
            // buttonEditMembership
            // 
            this.buttonEditMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditMembership.Location = new System.Drawing.Point(7, 62);
            this.buttonEditMembership.Name = "buttonEditMembership";
            this.buttonEditMembership.Size = new System.Drawing.Size(299, 33);
            this.buttonEditMembership.TabIndex = 1;
            this.buttonEditMembership.Text = "Edit this membership";
            this.buttonEditMembership.UseVisualStyleBackColor = true;
            this.buttonEditMembership.Click += new System.EventHandler(this.buttonEditMembership_Click);
            // 
            // buttonAddMembership
            // 
            this.buttonAddMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddMembership.Location = new System.Drawing.Point(7, 22);
            this.buttonAddMembership.Name = "buttonAddMembership";
            this.buttonAddMembership.Size = new System.Drawing.Size(299, 33);
            this.buttonAddMembership.TabIndex = 0;
            this.buttonAddMembership.Text = "Add new membership";
            this.buttonAddMembership.UseVisualStyleBackColor = true;
            this.buttonAddMembership.Click += new System.EventHandler(this.buttonAddMembership_Click);
            // 
            // dataGridViewMembership
            // 
            this.dataGridViewMembership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMembership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMembership.Location = new System.Drawing.Point(3, 136);
            this.dataGridViewMembership.Name = "dataGridViewMembership";
            this.dataGridViewMembership.RowHeadersWidth = 51;
            this.dataGridViewMembership.RowTemplate.Height = 24;
            this.dataGridViewMembership.Size = new System.Drawing.Size(1106, 395);
            this.dataGridViewMembership.TabIndex = 1;
            // 
            // UserControlMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlMembership";
            this.Size = new System.Drawing.Size(1112, 534);
            this.Load += new System.EventHandler(this.UserControlMembership_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembership)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDeleteMembership;
        private System.Windows.Forms.Button buttonEditMembership;
        private System.Windows.Forms.Button buttonAddMembership;
        private System.Windows.Forms.DataGridView dataGridViewMembership;
    }
}
