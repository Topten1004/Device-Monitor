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
    public partial class test_dbrecord : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int id;
        bool isDoubleClick = false;
        String connectString;

        bool tableReady = false;

        public test_dbrecord()
        {
            InitializeComponent();
            connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";
            GenerateDatabase();
        }

        private void dbrecord_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (tableReady == true)
            {
                x++;
                Console.WriteLine(x);
                try
                {
                    conn = new SQLiteConnection(connectString);
                    cmd = new SQLiteCommand();
                    cmd.CommandText = @"INSERT INTO device (time, actual_boiler_pressure, actual_bpv_pressure) VALUES(@time, @actual_boiler_pressure, @actual_bpv_pressure)";
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SQLiteParameter("@time", x.ToString()));
                    cmd.Parameters.Add(new SQLiteParameter("@actual_boiler_pressure", x + 2.ToString()));
                    cmd.Parameters.Add(new SQLiteParameter("@actual_bpv_pressure", x + 3.ToString()));
                    conn.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        Console.WriteLine("Successfully Created!");


                        //ReadData();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show();
                }
            }

        }

        private void GenerateDatabase()
        {
           

            String path = Application.StartupPath + @"\data.db";
            if (!File.Exists(path))
            {
                conn = new SQLiteConnection(connectString);
                conn.Open();
                string sql = "CREATE TABLE device (ID INTEGER PRIMARY KEY AUTOINCREMENT, time TEXT, actual_boiler_pressure TEXT, actual_bpv_pressure TEXT)";
                cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                tableReady = true;
            }
            else
            {
                tableReady = true;
            }
        }

        int x;
        
        
    }
}
