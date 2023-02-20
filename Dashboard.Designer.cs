
namespace devicemonitoring
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.graph_btn = new System.Windows.Forms.Button();
            this.setting_btn = new System.Windows.Forms.Button();
            this.dashbord_btn = new System.Windows.Forms.Button();
            this.database_btn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.Desktop;
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(293, 673);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(293, 444);
            this.panel4.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 50);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(293, 394);
            this.panel6.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.setting_btn);
            this.panel7.Controls.Add(this.dashbord_btn);
            this.panel7.Controls.Add(this.database_btn);
            this.panel7.Location = new System.Drawing.Point(27, 6);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(247, 369);
            this.panel7.TabIndex = 13;
            // 
            // graph_btn
            // 
            this.graph_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.graph_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.graph_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.graph_btn.FlatAppearance.BorderSize = 0;
            this.graph_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graph_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graph_btn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.graph_btn.Location = new System.Drawing.Point(27, 29);
            this.graph_btn.Margin = new System.Windows.Forms.Padding(4);
            this.graph_btn.Name = "graph_btn";
            this.graph_btn.Size = new System.Drawing.Size(225, 50);
            this.graph_btn.TabIndex = 11;
            this.graph_btn.Text = "Graph";
            this.graph_btn.UseVisualStyleBackColor = false;
            this.graph_btn.Visible = false;
            this.graph_btn.Click += new System.EventHandler(this.graph_btn_Click);
            // 
            // setting_btn
            // 
            this.setting_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.setting_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.setting_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.setting_btn.FlatAppearance.BorderSize = 0;
            this.setting_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_btn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.setting_btn.Location = new System.Drawing.Point(11, 231);
            this.setting_btn.Margin = new System.Windows.Forms.Padding(4);
            this.setting_btn.Name = "setting_btn";
            this.setting_btn.Size = new System.Drawing.Size(225, 50);
            this.setting_btn.TabIndex = 8;
            this.setting_btn.Text = "Setting";
            this.setting_btn.UseVisualStyleBackColor = false;
            this.setting_btn.Click += new System.EventHandler(this.modbustest_Click);
            // 
            // dashbord_btn
            // 
            this.dashbord_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dashbord_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.dashbord_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dashbord_btn.FlatAppearance.BorderSize = 0;
            this.dashbord_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashbord_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashbord_btn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dashbord_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashbord_btn.Location = new System.Drawing.Point(11, 47);
            this.dashbord_btn.Margin = new System.Windows.Forms.Padding(4);
            this.dashbord_btn.Name = "dashbord_btn";
            this.dashbord_btn.Size = new System.Drawing.Size(225, 50);
            this.dashbord_btn.TabIndex = 12;
            this.dashbord_btn.Text = "Dashboard";
            this.dashbord_btn.UseVisualStyleBackColor = false;
            this.dashbord_btn.Click += new System.EventHandler(this.dashbord_btn_Click);
            // 
            // database_btn
            // 
            this.database_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.database_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.database_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.database_btn.FlatAppearance.BorderSize = 0;
            this.database_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.database_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.database_btn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.database_btn.Location = new System.Drawing.Point(11, 131);
            this.database_btn.Margin = new System.Windows.Forms.Padding(4);
            this.database_btn.Name = "database_btn";
            this.database_btn.Size = new System.Drawing.Size(225, 50);
            this.database_btn.TabIndex = 10;
            this.database_btn.Text = "Database";
            this.database_btn.UseVisualStyleBackColor = false;
            this.database_btn.Click += new System.EventHandler(this.report_btn_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(293, 50);
            this.panel5.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.graph_btn);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 544);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 129);
            this.panel3.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(93, 31);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 100);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(27, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(104, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monitoring";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(293, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 43);
            this.panel2.TabIndex = 3;
            // 
            // mainpanel
            // 
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(293, 43);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(968, 630);
            this.mainpanel.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1261, 673);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Text = "Asko Device Monitoring";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button setting_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button database_btn;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Button graph_btn;
        private System.Windows.Forms.Button dashbord_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

