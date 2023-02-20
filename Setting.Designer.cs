
namespace devicemonitoring
{
    partial class Setting
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UpdateInterval_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.interval_txt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ipaddress_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connect_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.UpdateInterval_btn);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.interval_txt);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(57, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 86);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interval";
            // 
            // UpdateInterval_btn
            // 
            this.UpdateInterval_btn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.UpdateInterval_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UpdateInterval_btn.FlatAppearance.BorderSize = 0;
            this.UpdateInterval_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateInterval_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateInterval_btn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.UpdateInterval_btn.Location = new System.Drawing.Point(418, 22);
            this.UpdateInterval_btn.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateInterval_btn.Name = "UpdateInterval_btn";
            this.UpdateInterval_btn.Size = new System.Drawing.Size(175, 42);
            this.UpdateInterval_btn.TabIndex = 21;
            this.UpdateInterval_btn.Text = "Update";
            this.UpdateInterval_btn.UseVisualStyleBackColor = false;
            this.UpdateInterval_btn.Click += new System.EventHandler(this.UpdateInterval_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(298, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "/ second";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(15, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Interval";
            // 
            // interval_txt
            // 
            this.interval_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interval_txt.Location = new System.Drawing.Point(200, 28);
            this.interval_txt.Name = "interval_txt";
            this.interval_txt.Size = new System.Drawing.Size(81, 30);
            this.interval_txt.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.ipaddress_txt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.connect_btn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(57, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 95);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address Setting";
            // 
            // ipaddress_txt
            // 
            this.ipaddress_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipaddress_txt.Location = new System.Drawing.Point(200, 37);
            this.ipaddress_txt.Name = "ipaddress_txt";
            this.ipaddress_txt.Size = new System.Drawing.Size(185, 30);
            this.ipaddress_txt.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(15, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "IP Address";
            // 
            // connect_btn
            // 
            this.connect_btn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.connect_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.connect_btn.FlatAppearance.BorderSize = 0;
            this.connect_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect_btn.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.connect_btn.Location = new System.Drawing.Point(418, 31);
            this.connect_btn.Margin = new System.Windows.Forms.Padding(4);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(175, 43);
            this.connect_btn.TabIndex = 8;
            this.connect_btn.Text = "Connect";
            this.connect_btn.UseVisualStyleBackColor = false;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(23, 75);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(742, 379);
            this.panel1.TabIndex = 26;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(807, 552);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Setting";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Setting";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button UpdateInterval_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox interval_txt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ipaddress_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.Panel panel1;
    }
}