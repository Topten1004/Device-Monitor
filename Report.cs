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
    public partial class Report : Form
    {

        String connectString;

        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();



        SQLiteDataAdapter adapter2;
        DataSet ds2 = new DataSet();
        DataTable dt2 = new DataTable();




        string time;

        

        public Report()
        {
            InitializeComponent();

            connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";

                       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Report_Load(object sender, EventArgs e)
        {
            ReadDb();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Dashboard.statusConnection == "connect")
            {
                ReadDb();
                if (Dashboard.anyUpdate == true)
                {
                    Timer.Interval = Dashboard.interval * 1000;
                    //Console.WriteLine("REPORT_interval : " + Timer.Interval);
                }


                time = DateTime.Now.ToString("h:mm:ss tt");
            }          
            
        }

        //########################################################

        private void ReadDb()
        {
            try
            {
                //var dateAndTime = DateTime.Now;
                //var date = dateAndTime.Date;

                var date = DateTime.Now.ToString("yyyy-MM-dd");
                //Console.WriteLine(date);

                //dataGridView1.Visible = false;

                conn = new SQLiteConnection(connectString);
                conn.Open();
                cmd = new SQLiteCommand();
                //String sql = "SELECT * FROM device";
                String sql = $"SELECT * FROM boiler WHERE date='{date}'";
                adapter = new SQLiteDataAdapter(sql, conn);
                ds.Reset();
                adapter.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                conn.Close();
                dataGridView1.Columns[1].HeaderText = "date";
                dataGridView1.Columns[2].HeaderText = "time";
                dataGridView1.Columns[3].HeaderText = "actual_boiler_pressure";                
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;                
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //int rowcount = dataGridView1.Rows.Count;
                //dataGridView1.FirstDisplayedScrollingRowIndex = rowcount;                         


                //BPV
                
                conn = new SQLiteConnection(connectString);
                conn.Open();
                cmd = new SQLiteCommand();
                String sqlBpv = $"SELECT * FROM bpv WHERE date='{date}'";
                adapter2 = new SQLiteDataAdapter(sqlBpv, conn);
                ds2.Reset();
                adapter2.Fill(ds2);
                dt2 = ds2.Tables[0];
                dataGridView2.DataSource = dt2;
                conn.Close();
                dataGridView2.Columns[1].HeaderText = "date";
                dataGridView2.Columns[2].HeaderText = "time";
                dataGridView2.Columns[3].HeaderText = "actual_bpv_pressure";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("error from report");
                Console.WriteLine(ex.Message);
            }
        }



        // export              

        private void button1_Click_1(object sender, EventArgs e)
        {
            generateCSV();
        }


        private void generateCSV()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            string x = time.Trim();

            string dir = @"Export";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //writeCSV(dataGridView1, "result.csv");
            writeCSV(dataGridView1, $@"Export\report-boiler-{date}.csv");
            writeCSV(dataGridView2, $@"Export\report-bpv-{date}.csv");
            //MessageBox.Show("Converted successfully to *.csv format");
        }

                
        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
                for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 2; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
            }
        }






    }
}










/*
string time = DateTime.Now.ToString("hh:mm:ss tt");

for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
{
    Console.WriteLine( dataGridView1.Columns[i - 1].HeaderText);
}

for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
{
    for (int j = 0; j < dataGridView1.Columns.Count; j++)
    {
        Console.WriteLine(dataGridView1.Rows[i].Cells[j].Value.ToString());
    }
}

            
StringBuilder csvcontent = new StringBuilder();
csvcontent.AppendLine("Name, age");
csvcontent.AppendLine($"Dex,{time}");
string csvpath = $@"Export\Data{time.ToString()}.csv";
File.AppendAllText(csvpath, csvcontent.ToString());
Console.WriteLine("Created File !");

*/















/* pada button clicknya
writeCSV(dataGridView1, "result.csv");
MessageBox.Show("Converted successfully to *.csv format");
*/

/*
 * public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
                for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
            }
        }



*/