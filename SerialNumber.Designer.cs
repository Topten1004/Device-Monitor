
namespace devicemonitoring
{
    partial class SerialNumber
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.activate_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.serialNumber_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deviceKey_tb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.activate_btn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.serialNumber_tb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.deviceKey_tb);
            this.panel1.Location = new System.Drawing.Point(111, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 289);
            this.panel1.TabIndex = 0;
            // 
            // activate_btn
            // 
            this.activate_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activate_btn.Location = new System.Drawing.Point(623, 196);
            this.activate_btn.Name = "activate_btn";
            this.activate_btn.Size = new System.Drawing.Size(134, 38);
            this.activate_btn.TabIndex = 4;
            this.activate_btn.Text = "Activate";
            this.activate_btn.UseVisualStyleBackColor = true;
            this.activate_btn.Click += new System.EventHandler(this.activate_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serial Number";
            // 
            // serialNumber_tb
            // 
            this.serialNumber_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumber_tb.Location = new System.Drawing.Point(197, 136);
            this.serialNumber_tb.Name = "serialNumber_tb";
            this.serialNumber_tb.Size = new System.Drawing.Size(560, 30);
            this.serialNumber_tb.TabIndex = 2;
            this.serialNumber_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device Key";
            // 
            // deviceKey_tb
            // 
            this.deviceKey_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceKey_tb.Location = new System.Drawing.Point(197, 77);
            this.deviceKey_tb.Name = "deviceKey_tb";
            this.deviceKey_tb.Size = new System.Drawing.Size(560, 30);
            this.deviceKey_tb.TabIndex = 0;
            this.deviceKey_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SerialNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1048, 616);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerialNumber";
            this.Text = "SerialNumber";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button activate_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serialNumber_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deviceKey_tb;
    }
}