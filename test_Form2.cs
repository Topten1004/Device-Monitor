using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Management;

namespace devicemonitoring
{
    public partial class test_Form2 : Form
    {
        public test_Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagementObjectCollection objectList = null;
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("Select * From Win32_processor");
            objectList = objectSearcher.Get();
            string id = "";
            foreach(ManagementObject obj in objectList)
            {
                id = obj["ProcessorID"].ToString();
            }
            objectSearcher = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            objectList = objectSearcher.Get();
            string mtherBoard = "";
            foreach (ManagementObject obj in objectList)
            {
                mtherBoard = (string)obj["SerialNumber"];

            }
            string uniqueId = id + mtherBoard;
            //MessageBox.Show(uniqueId);
        }
    }
}
