using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace devicemonitoring
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
                      

            Console.WriteLine("baca interval dari main : " + Dashboard.interval);
            Console.WriteLine("baca actual_boiler_pressure : " + Dashboard.actual_boiler_pressure);

            createTimer();
            chart();
            chartRunning();
            gauge();

        }

       


        private void TimerOnTick(object sender, EventArgs eventArgs)
        {

            if (Dashboard.statusConnection == "connect")
            {
                chartRunning();
                gauge();
            }

        }



        //GRAPH

        //chart boiler
        private ChartValues<MeasureModel> ChartValuesBoiler { get; set; }

        //chart bpv
        private ChartValues<MeasureModel> ChartValuesBPV { get; set; }


        public Timer Timer { get; set; }
       
        private void createTimer()
        {
            
            if(Dashboard.interval == 0)
            {
                Dashboard.interval = 30;
            }
                                  

            Timer = new Timer
            {
                Interval = Dashboard.interval * 1000
            };
            Timer.Tick += TimerOnTick;
            Timer.Start();
        }

        private void chart()
        {
            //Graph
            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)
                .Y(model => model.Value);
            Charting.For<MeasureModel>(mapper);


            //chart boiler
            ChartValuesBoiler = new ChartValues<MeasureModel>();
            Boiler_cartesianChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = ChartValuesBoiler,
                    PointGeometrySize = 18,
                    StrokeThickness = 2
                },

            };
            Boiler_cartesianChart.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("HH:mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(Dashboard.interval).Ticks
                }
            });
            Boiler_cartesianChart.AxisY.Add(new Axis
            {
                Title = "Boiler Pressure",
                MinValue = 0,
                MaxValue = 100
            });



            //chart bpv
            ChartValuesBPV = new ChartValues<MeasureModel>();
            BPV_cartesianChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = ChartValuesBPV,
                    PointGeometrySize = 18,
                    StrokeThickness = 2,
                    
                },

            };
            BPV_cartesianChart.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("HH:mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(Dashboard.interval).Ticks
                }
            });
            BPV_cartesianChart.AxisY.Add(new Axis
            {
                Title = "BPV Pressure",
                MinValue = 0,
                MaxValue = 100
            });


            SetAxisLimits(System.DateTime.Now);
        }
        private void SetAxisLimits(System.DateTime now)
        {

            //chart boiler
            Boiler_cartesianChart.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            Boiler_cartesianChart.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(Dashboard.interval * 6).Ticks; //we only care about the last 8 seconds

            //chart bpv
            BPV_cartesianChart.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            BPV_cartesianChart.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(Dashboard.interval * 6).Ticks; //we only care about the last 8 seconds
        }



        private void chartRunning()
        {
            var now = System.DateTime.Now;

            //chart boiler
            ChartValuesBoiler.Add(new MeasureModel
            {
                DateTime = now,
                Value = Dashboard.actual_boiler_pressure
            });

            //chart bpv
            ChartValuesBPV.Add(new MeasureModel
            {
                DateTime = now,
                Value = Dashboard.actual_bpv_pressure
            });


            SetAxisLimits(now);
            if (ChartValuesBoiler.Count > 30) ChartValuesBoiler.RemoveAt(0);
            //Console.WriteLine("interval Main : " + Timer.Interval);
        }


        //Gauge 
        private void gauge()
        {
            Boiler_solidGauge.From = 0;
            Boiler_solidGauge.To = 100;
            Boiler_solidGauge.Value = Math.Round(Dashboard.actual_boiler_pressure,2);
            boiler_lbl.Text = Math.Round(Dashboard.actual_boiler_pressure, 2).ToString();

            BPV_solidGauge.From = 0;
            BPV_solidGauge.To = 100;
            BPV_solidGauge.Value = Math.Round(Dashboard.actual_bpv_pressure, 2);
            bpv_lbl.Text = Math.Round(Dashboard.actual_bpv_pressure, 2).ToString();
        }


    }
}
