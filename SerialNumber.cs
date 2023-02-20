using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Data.SQLite;
using System.IO;


namespace devicemonitoring
{
    public partial class SerialNumber : Form
    {

        public static string license;


        //sqlite connection
        SQLiteConnection conn;
        SQLiteCommand cmd;
        String connectString;

        public static bool closeApp = false;



        public SerialNumber()
        {
            InitializeComponent();

            deviceKey_tb.Text = Dashboard.deviceId;

            connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";



        }

        private void activate_btn_Click(object sender, EventArgs e)
        {
            var textBytes = Encoding.UTF8.GetBytes(Dashboard.deviceId);
            var base64String = Convert.ToBase64String(textBytes, 6, 10);
                        
            if(base64String == serialNumber_tb.Text)
            {
                updateLisenceDb();
                MessageBox.Show("License berhasil, Buka Ulang Aplikasi !!");
                Dashboard.softwareStatus = "aktif";
                closeApp = true;
                
            }
            else
            {
                MessageBox.Show("Serial Number Salah");
                Dashboard.softwareStatus = "tidak aktif";
            }            
            
        }





        private void updateLisenceDb()
        {
            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"UPDATE license SET serial_number=@serial_number WHERE id = 1";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@serial_number", serialNumber_tb.Text));               
                conn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Console.WriteLine("Update License berhasil!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from updateLicenseDB");
                Console.WriteLine(ex.Message);
                return;
            }

        }

              




    }
}
