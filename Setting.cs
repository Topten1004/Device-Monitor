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
    public partial class Setting : Form
    {

        SQLiteConnection conn;
        SQLiteCommand cmd;
        String connectString;       


        public Setting()
        {
            InitializeComponent();

            UpdateInterval_btn.Enabled = false;
            interval_txt.Enabled = false;




            connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";

            ipaddress_txt.Text = Dashboard.ipaddress;            
            interval_txt.Text = Dashboard.interval.ToString();

            if (Dashboard.statusConnection == "connect")
            {
                connect_btn.Text = "Disconnect";
                ipaddress_txt.Enabled = false;               
            }
            
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            if (Dashboard.statusConnection == "disconnect")
            {
                connect_btn.Text = "Disconnect";
                ipaddress_txt.Enabled = false;
                Dashboard.statusConnection = "connect";
                UpdateDB_setting();
            }
            else
            {
                connect_btn.Text = "Connect";
                ipaddress_txt.Enabled = true;
                Dashboard.statusConnection = "disconnect";
                UpdateDB_setting();
            }
            Dashboard.anyUpdate = true;
        }

        private void UpdateInterval_btn_Click(object sender, EventArgs e)
        {
            UpdateDB_setting();
            Dashboard.anyUpdate = true;
        }


        
        public Setting(string statusConnection) //coba tambahan
        {
            Dashboard.statusConnection = statusConnection;
            try
            {
                connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"UPDATE setting SET ipaddress=@ipaddress, interval=@interval, connect_status=@connect_status WHERE id = 1";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@ipaddress", Dashboard.ipaddress));
                cmd.Parameters.Add(new SQLiteParameter("@interval", Dashboard.interval));
                cmd.Parameters.Add(new SQLiteParameter("@connect_status", statusConnection));
                conn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Console.WriteLine("force -->>> setting berhasil!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from updateDBSetting tambahan");
                Console.WriteLine(ex.Message);
                return;
            }
        }
        



        private void UpdateDB_setting()
        {            
            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"UPDATE setting SET ipaddress=@ipaddress, interval=@interval, connect_status=@connect_status WHERE id = 1";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@ipaddress", ipaddress_txt.Text));
                cmd.Parameters.Add(new SQLiteParameter("@interval", Int16.Parse(interval_txt.Text)));
                cmd.Parameters.Add(new SQLiteParameter("@connect_status", Dashboard.statusConnection));
                conn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Console.WriteLine("Update setting berhasil!");
                    MessageBox.Show("Update Setting Berhasil !!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from updateDBSetting");
                Console.WriteLine(ex.Message);
                return;
            }            
        }
        


        
              
    }
}
