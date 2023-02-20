using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyModbus;
using System.Data.SQLite;
using System.IO;

using DeviceId;
using System.Management;
using System.Threading;

namespace devicemonitoring
{
    public partial class Dashboard : Form
    {

        public static string deviceId;

        public static string softwareStatus;

        public static bool anyUpdate = false;
       
        public static string ipaddress;
        //public static int startRegister;
        //public static int jumlahRegister;
        public static string statusConnection;
        
        public static int interval;
        

        //Address
        public static int actual_boiler_pressure_address = 0;
        public static int actual_bpv_pressure_address = 2;


        //Data
        public static float actual_boiler_pressure;
        public static float actual_bpv_pressure;

        //sqlite connection
        SQLiteConnection conn;
        SQLiteCommand cmd;                 
        String connectString;


        //GRIDVIEW HIDDEN
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();


        public static string date;
        public static string time;


        public static string serial_number;



        public Dashboard()
        {
            InitializeComponent();
            connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";

            GenerateDatabase();
            getDeviceId();
            checkLicense();

            initialApp();


            

        }
        public void loadform(object Form)
        {            

            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
                                   
        }


        private void initialApp()
        {
            dataGridView1.Visible = false;
            if (softwareStatus == "aktif")
            {            
                
                readSetting();
                anyUpdate = true;

                ReadDb();
                dashbord_btn.Enabled = true;
                graph_btn.Enabled = false;
                database_btn.Enabled = true;
                setting_btn.Enabled = true;

                SaveToDb();
                

                loadform(new Main());

                

            }
            else
            {
                loadform(new SerialNumber());
                dashbord_btn.Enabled = false;
                graph_btn.Enabled = false;
                database_btn.Enabled = false;
                setting_btn.Enabled = false;
            }
        }


        private void report_btn_Click(object sender, EventArgs e)
        {
            loadform(new Report());
        }

        private void modbustest_Click(object sender, EventArgs e)
        {
            loadform(new Setting());
            //Form setting = new Setting();
            //setting.ShowDialog();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
                        
            if (statusConnection == "connect")
            {

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                
                if (anyUpdate == true)
                {
                    readSetting();
                    Timer.Interval = interval * 1000;
                    anyUpdate = false;
                }


                /*
                date = DateTime.Now.ToString("yyyy-MM-dd");
                time = DateTime.Now.ToString("h:mm:ss tt");

                SaveToDb();
                ReadDb();
                //Console.WriteLine("Dashboard_interval :" + Timer.Interval);                

                if (anyUpdate == true)
                {
                    readSetting();
                    Timer.Interval = interval * 1000;
                    anyUpdate = false;
                }


                
                Console.WriteLine("time : "+time);
                if(time == "11:59:59 PM")
                {
                    Console.WriteLine("BERHASIL EXPORT FILE");
                    //MessageBox.Show("BERHASIL EXPORT FILE");
                    generateCSV();
                }
                */

            }
            
            
        }



        //#######################################################
                

        private void GenerateDatabase()
        {
            String path = Application.StartupPath + @"\data.db";
            if (!File.Exists(path))
            {
                conn = new SQLiteConnection(connectString);
                conn.Open();
                string sqlBoiler = "CREATE TABLE boiler (id INTEGER PRIMARY KEY AUTOINCREMENT, date TEXT, time TEXT, actual_boiler_pressure TEXT)";
                cmd = new SQLiteCommand(sqlBoiler, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn = new SQLiteConnection(connectString);
                conn.Open();
                string sqlBPV = "CREATE TABLE bpv (id INTEGER PRIMARY KEY AUTOINCREMENT, date TEXT, time TEXT, actual_bpv_pressure TEXT)";
                cmd = new SQLiteCommand(sqlBPV, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn = new SQLiteConnection(connectString);
                conn.Open();
                string sqlSetting = "CREATE TABLE setting (id INTEGER PRIMARY KEY AUTOINCREMENT, ipaddress TEXT, interval INT, connect_status TEXT)";
                cmd = new SQLiteCommand(sqlSetting, conn);
                cmd.ExecuteNonQuery();
                conn.Close();


                conn = new SQLiteConnection(connectString);
                conn.Open();
                string sqlLicense = "CREATE TABLE license (id INTEGER PRIMARY KEY AUTOINCREMENT, serial_number TEXT)";
                cmd = new SQLiteCommand(sqlLicense, conn);
                cmd.ExecuteNonQuery();
                conn.Close();



                firstInsertSetting();
                firstLicense();
            }            
        }


        private void SaveToDb()
        {
            try
            {
                //string date = DateTime.Now.ToShortDateString();
                //DateTime date = DateTime.Now;
                //var dateAndTime = DateTime.Now;
                //var date = dateAndTime.Date;
                

                //Console.WriteLine(date);
                //Console.WriteLine(time);
                


                ModbusClient modbusClient = new ModbusClient(ipaddress, 502);
                modbusClient.Connect();
                //Int32[] data = modbusClient.ReadHoldingRegisters(startRegister, jumlahRegister);

                actual_boiler_pressure = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(actual_boiler_pressure_address, 2), ModbusClient.RegisterOrder.HighLow);
                actual_bpv_pressure = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(actual_bpv_pressure_address, 2), ModbusClient.RegisterOrder.HighLow);

                //Save to SQLite DB
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"INSERT INTO boiler (date, time, actual_boiler_pressure) VALUES(@date, @time, @actual_boiler_pressure);
                                    INSERT INTO bpv (date, time, actual_bpv_pressure) VALUES(@date, @time, @actual_bpv_pressure);";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@date", date));
                cmd.Parameters.Add(new SQLiteParameter("@time", time));
                cmd.Parameters.Add(new SQLiteParameter("@actual_boiler_pressure", Math.Round(actual_boiler_pressure, 2) ));
                cmd.Parameters.Add(new SQLiteParameter("@actual_bpv_pressure", Math.Round(actual_bpv_pressure,2) ));                              

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    //Console.WriteLine("divice data saved !");
                }
                conn.Close();


                //save to SQL Server DB
                SqlServerDB saveToSqlServer = new SqlServerDB(actual_boiler_pressure, actual_bpv_pressure);

                modbusClient.Disconnect();
            }
            catch (Exception error)
            {
                Console.WriteLine("error from saveToDB");
                Console.WriteLine(error.Message);

                handleDisconnected();
            }
        }


        private void firstInsertSetting()
        {
            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"INSERT INTO setting (ipaddress, interval, connect_status) VALUES(@ipaddress, @interval, @connect_status)";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@ipaddress", "127.0.0.1"));
                cmd.Parameters.Add(new SQLiteParameter("@interval", 30));
                cmd.Parameters.Add(new SQLiteParameter("@connect_status", "disconnect"));
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Console.WriteLine("firstInsertSetting triggered");
                }
                conn.Close();
                
            }
            catch (Exception error)
            {
                Console.WriteLine("error from firstInsertSetting");
                Console.WriteLine(error.Message);
            }

        }

        private void firstLicense()
        {
            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = @"INSERT INTO license (serial_number) VALUES(@serial_number)";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@serial_number", "trial"));                
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Console.WriteLine("serial number first setting");
                }
                conn.Close();

            }
            catch (Exception error)
            {
                Console.WriteLine("error from fistLicense");
                Console.WriteLine(error.Message);
            }
        }



        private void readSetting()
        {
            try
            {               
                conn = new SQLiteConnection(connectString);
                conn.Open();
                string sql = "SELECT * FROM setting WHERE id=1";
                cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ipaddress = reader["ipaddress"].ToString();
                    interval = Int16.Parse(reader["interval"].ToString());
                    statusConnection = reader["connect_status"].ToString();


                    //Console.WriteLine(ipaddress);
                    //Console.WriteLine(interval);
                    //Console.WriteLine(statusConnection);
                }
                reader.Close();
                conn.Close();


            }
            catch (Exception error)
            {
                Console.WriteLine("error from read setting");
                Console.WriteLine(error.Message);
            }
        }


        //*********************

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void disconnect_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void test_btn_Click(object sender, EventArgs e)
        {


        }

        private void graph_btn_Click(object sender, EventArgs e)
        {
            loadform(new Graph());
        }

        private void dashbord_btn_Click(object sender, EventArgs e)
        {
            loadform(new Main());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            generateCSV();
        }







        //GRID VIEW HIDEN *************************************************************

        
        
        private void ReadDb()
        {
            try
            {                

                var date = DateTime.Now.ToString("yyyy-MM-dd");
                Console.WriteLine("date : "+date);

                dataGridView1.Visible = false;

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
                dataGridView1.Columns[1].HeaderText = "Date";
                dataGridView1.Columns[2].HeaderText = "Time";
                dataGridView1.Columns[3].HeaderText = "actual_boiler_pressure";               
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;                
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;              
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from ReadDb dashboard");
                Console.WriteLine(ex.Message);

                handleDisconnected();
            }            
        }




        //generate CSV
        private void generateCSV()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            
            string dir = @"Export";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //writeCSV(dataGridView1, "result.csv");
            writeCSV(dataGridView1, $@"Export\report-{date}.csv");
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











        private void getDeviceId()
        {
            ManagementObjectCollection objectList = null;
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("Select * From Win32_processor");
            objectList = objectSearcher.Get();
            string id = "";
            foreach (ManagementObject obj in objectList)
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
            deviceId = uniqueId;
            
        }








        private void checkLicense()
        {
            
            try
            {
                conn = new SQLiteConnection(connectString);
                conn.Open();
                string sql = "SELECT * FROM license WHERE id=1";
                cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    serial_number = reader["serial_number"].ToString();                
                }
                reader.Close();
                conn.Close();

                var textBytes = Encoding.UTF8.GetBytes(deviceId);
                var base64String = Convert.ToBase64String(textBytes, 6, 10);

                if (base64String == serial_number)
                {
                    softwareStatus = "aktif";
                    //MessageBox.Show(softwareStatus);
                }
                else
                {
                    softwareStatus = "tidak aktif";
                    //MessageBox.Show(softwareStatus);
                }


            }
            catch (Exception error)
            {
                Console.WriteLine("error from checkLicense");
                Console.WriteLine(error.Message);
            }
            

        }




        public void handleDisconnected()
        {
            conn.Close();
            ModbusClient modbusClient = new ModbusClient(ipaddress, 502);
            modbusClient.Disconnect();
            //statusConnection = "disconnect";
            Setting setting = new Setting("disconnect");
            MessageBox.Show("KONEKSI TERPUTUS !!, \nPeriksa Koneksi dan Koneksikan Ulang");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            //while (statusConnection == "connect")
            //{
                date = DateTime.Now.ToString("yyyy-MM-dd");
                time = DateTime.Now.ToString("h:mm:ss tt");

                SaveToDb();
                ReadDb();
                //Console.WriteLine("Dashboard_interval :" + Timer.Interval);                

                //if (anyUpdate == true)
                //{
                //    readSetting();
                //    Timer.Interval = interval * 1000;
               //     anyUpdate = false;
                //}

                Console.WriteLine("time : " + time);
                if (time == "11:59:59 PM")
                {
                    Console.WriteLine("BERHASIL EXPORT FILE");
                    //MessageBox.Show("BERHASIL EXPORT FILE");
                    generateCSV();
                }
                //Thread.Sleep(interval);
                Console.WriteLine("Thread Running");
            //}
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }

}




/*


//"SELECT ipaddress FROM setting WHERE id = 1"

//contoh good get row value
conn = new SQLiteConnection(connectString);
conn.Open();
string sql = "SELECT * FROM setting";
cmd = new SQLiteCommand(sql, conn);
SQLiteDataReader reader = cmd.ExecuteReader();                                
while (reader.Read())
{
    Console.WriteLine(reader["ipaddress"].ToString());                    
}                
reader.Close();                                            
conn.Close();



*/




/*

using (var connection = new SQLiteConnection(connectString))
using (var command = connection.CreateCommand())
{
    connection.Open();
    command.CommandText = @"insert into Stock([Product]) values (@Product);
        insert into LandhuisMisje([Product]) values (@Product);
        insert into TheWineCellar([Product]) values (@Product);"
    command.Parameters.AddWithValue("@Product", AddProductTables.Text);
    command.ExecuteNonQuery()
}
*/