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

using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace devicemonitoring
{
    public partial class Graph : Form
    {

        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int id;
        bool isDoubleClick = false;
        String connectString;

        string selectedItemGraph;
        float selectedGraphValue;
       


        int counter = 0;
        public Graph()
        {            

            InitializeComponent();

            AddSelectGraphItem();

            //database         
            connectString = @"Data Source=" + Application.StartupPath + @"\data.db;version=3";


            //Graph
            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)  
                .Y(model => model.Value);        
                                 
            Charting.For<MeasureModel>(mapper);           
            ChartValues = new ChartValues<MeasureModel>();
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = ChartValues,
                    PointGeometrySize = 18,
                    StrokeThickness = 2
                },
                
            };
            cartesianChart1.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("HH:mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(Dashboard.interval).Ticks
                }
            });

            SetAxisLimits(System.DateTime.Now);
            Timer = new Timer
            {
                Interval = Dashboard.interval * 1000
            };
            Timer.Tick += TimerOnTick;
            R = new Random();
            Timer.Start();

        }

                

        private ChartValues<MeasureModel> ChartValues { get; set; }
       
        public Timer Timer { get; set; }
        public Random R { get; set; }

        private void SetAxisLimits(System.DateTime now)
        {
            //cartesianChart1.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            //cartesianChart1.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(8).Ticks; //we only care about the last 8 seconds
            cartesianChart1.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            cartesianChart1.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(Dashboard.interval * 6).Ticks; //we only care about the last 8 seconds
        }

        
        private void TimerOnTick(object sender, EventArgs eventArgs)
        {

            if(Dashboard.statusConnection == "connect")
            {
                //ReadDb();
                selectValue();

                var now = System.DateTime.Now;
                ChartValues.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = selectedGraphValue

                });
                SetAxisLimits(now);
                if (ChartValues.Count > 30) ChartValues.RemoveAt(0);

                Console.WriteLine("interval Graph: " + Timer.Interval);
            }
                        
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        

        private void selectGraph_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItemGraph = selectGraph_cb.SelectedItem.ToString();            
        }

        private void AddSelectGraphItem()
        {            
            string[] items = {
                "actual_boiler_pressure",
                "actual_bpv_pressure"
            };
            selectGraph_cb.Items.AddRange(items);
        }

        private void selectValue()
        {
            switch (selectedItemGraph)
            {
                case "actual_boiler_pressure":
                    selectedGraphValue = Dashboard.actual_boiler_pressure;

                    try
                    {
                        conn = new SQLiteConnection(connectString);
                        conn.Open();
                        cmd = new SQLiteCommand();
                        String sql = "SELECT * FROM boiler";
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
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error from select report");
                        Console.WriteLine(e);
                    }
                    

                    break;


                case "actual_bpv_pressure":
                    selectedGraphValue = Dashboard.actual_bpv_pressure;

                    try
                    {
                        conn = new SQLiteConnection(connectString);
                        conn.Open();
                        cmd = new SQLiteCommand();
                        String sqlBpv = "SELECT * FROM bpv";
                        adapter = new SQLiteDataAdapter(sqlBpv, conn);
                        ds.Reset();
                        adapter.Fill(ds);
                        dt = ds.Tables[0];
                        dataGridView1.DataSource = dt;
                        conn.Close();
                        dataGridView1.Columns[1].HeaderText = "date";
                        dataGridView1.Columns[2].HeaderText = "time";
                        dataGridView1.Columns[3].HeaderText = "actual_bpv_pressure";
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error from select report");
                        Console.WriteLine(e);
                    }
                    
                    break;

                default:
                    selectedGraphValue = Dashboard.actual_bpv_pressure;
                    break;
            }
        }


    }
}









/*

private void ReadDb()
{
    try
    {
        conn = new SQLiteConnection(connectString);
        conn.Open();
        cmd = new SQLiteCommand();
        String sql = "SELECT * FROM boiler";
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



        conn = new SQLiteConnection(connectString);
        conn.Open();
        cmd = new SQLiteCommand();
        String sqlBpv = "SELECT * FROM bpv";
        adapter = new SQLiteDataAdapter(sqlBpv, conn);
        ds.Reset();
        adapter.Fill(ds);
        dt = ds.Tables[0];
        dataGridView1.DataSource = dt;
        conn.Close();
        dataGridView1.Columns[1].HeaderText = "date";
        dataGridView1.Columns[2].HeaderText = "time";
        dataGridView1.Columns[3].HeaderText = "actual_bpv_pressure";
        dataGridView1.Columns[0].Visible = false;
        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //int rowcount = dataGridView1.Rows.Count;
        //dataGridView1.FirstDisplayedScrollingRowIndex = rowcount;

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


*/