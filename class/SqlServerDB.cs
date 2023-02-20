using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace devicemonitoring
{
    class SqlServerDB
    {
        //string connectionString = @"Data Source=DEKUZ-PC\SQLEXPRESS;Initial Catalog=bbs_bpv;User ID=dekuz;Password=dekuz";
        string connectionString = @"Data Source=SRVBBSPLC\SQLEXPRESS;Initial Catalog=bbs_bpv;User ID=user_bpv;Password=user_bpv";
        SqlConnection conn;

        SqlCommand cmd;
        

        public SqlServerDB(float actual_boiler_pressure,float actual_bpv_pressure)
        {
            try
            {               

                conn = new SqlConnection(connectionString);

                cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Table_boiler (TANGGAL, WAKTU, TEKANAN_BOILER) VALUES(@date, @time, @actual_boiler_pressure);
                                    INSERT INTO Table_bpv (TANGGAL, WAKTU, TEKANAN_BPV) VALUES(@date, @time, @actual_bpv_pressure);";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SqlParameter("@date", Dashboard.date));
                cmd.Parameters.Add(new SqlParameter("@time", Dashboard.time));
                cmd.Parameters.Add(new SqlParameter("@actual_boiler_pressure", Math.Round(actual_boiler_pressure, 2).ToString()));
                cmd.Parameters.Add(new SqlParameter("@actual_bpv_pressure", Math.Round(actual_bpv_pressure, 2).ToString()));

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Console.WriteLine("SQL SERVER ----->>>  data saved !");
                }
                conn.Close();


            }
            catch(Exception e)
            {
                Console.WriteLine("error from class sqlServerDB");
                Console.WriteLine(e);
                conn.Close();
            }
            
        }



        
    }
}
