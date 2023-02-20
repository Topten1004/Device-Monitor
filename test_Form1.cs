using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;


namespace devicemonitoring
{
    public partial class test_Form1 : Form
    {
        public test_Form1()
        {
            InitializeComponent();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            
            
        }

        int count;
        int timeCount;
        int test;
        private void timer_Tick(object sender, EventArgs e)
        {
            count++;
            test++;
            //string time = DateTime.Now.ToString();
            string time = DateTime.Now.ToString("hh:mm:ss tt");
            //Console.WriteLine(time);


            string dir = @"Export";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            StringBuilder csvcontent = new StringBuilder();                        
            if(count == 1)
            {
                csvcontent.AppendLine("Name, age");                
            }
            for(int i = 0; i < 10; i++)
            {
                csvcontent.AppendLine($"Dex,{count}");
            }
                        

            //string csvpath = "D:\\zzz.csv";
            if (count == 10)
            {
                string csvpath = $@"Export\Data{test.ToString()}.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());
                //Console.WriteLine("Created File !");
                count = 0;
            }
            

        }     


    }
}


/*
StringBuilder csvcontent = new StringBuilder();
csvcontent.AppendLine("Name, age");
csvcontent.AppendLine($"Dex,{count}");
string csvpath = $@"Export\Data{test.ToString()}.csv";
File.AppendAllText(csvpath, csvcontent.ToString());
Console.WriteLine("Created File !");

*/