using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace devicemonitoring
{
    public partial class test_db : Form
    {

        string path = "data_table.db";
        string cs = @"URI=file:"+Application.StartupPath+"\\data_table.db";

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        public test_db()
        {
            InitializeComponent();
        }

        private void data_show()
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM test";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Insert(0, dr.GetString(0), dr.GetString(1));
            }
        }

        //create database and table
        private void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection("@Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "create table test(name varchar(20),id varchar(12))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Database cannot create");
                return;
            }
        }

        //insert data
        private void insert_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO test(name,id) VALUES (@name,id)";

                string NAME = name_txt.Text;
                string ID = id_txt.Text;

                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@id", ID);

                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Name";
                dataGridView1.Columns[1].Name = "Id";
                string[] row = new string[] { NAME, ID };
                dataGridView1.Rows.Add(row);

                cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                Console.WriteLine("Cannot insert data");
                return;
            }
        }

        private void db_Load(object sender, EventArgs e)
        {
            Create_db();
        }



        string connectionSting = @"DATA Source=|DataDirectory|\pengeluaran.db;versiom=3;";
        private void test()
        {
           
        }
        




    }
}
