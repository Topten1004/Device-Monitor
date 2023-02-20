using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace devicemonitoring
{
    class zUpdateDB
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


        

        public zUpdateDB(string time, string actual_boiler_pressure, string actual_bpv_pressure)
        {
            connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";
            GenerateDatabase();

            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"INSERT INTO device (time, actual_boiler_pressure, actual_bpv_pressure) VALUES(@time, @actual_boiler_pressure, @actual_bpv_pressure)";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@time", time));
                cmd.Parameters.Add(new SQLiteParameter("@actual_boiler_pressure", actual_boiler_pressure));
                cmd.Parameters.Add(new SQLiteParameter("@actual_bpv_pressure", actual_bpv_pressure));
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






    }
}
