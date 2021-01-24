        using MyoSharp.Communication;
        using MyoSharp.Device;
        using MyoSharp.Exceptions;
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        using System.Threading;
        using System.Diagnostics;
        using System.Windows.Forms.DataVisualization.Charting;
        
        namespace WindowsFormsApplication2
        {
            public partial class Form1 : Form
            {
        
                private Producer producer;
                private bool sitSensorOne = true;
                private bool sitSensorTwo = true;
                private bool sitSensorThree = true;
                private bool sitSensorFour = true;
                private bool sitSensorFive = true;
                private bool sitSensorSix = true;
                private bool sitSensorSeven = true;
                private bool sitSensorEighth = true;
        
                public Form1()
                {
                    InitializeComponent();
                    producer = new Producer(chart1);
                    producer.YSeriesEvent += MyHandler;
                    chart1.Series[0].Enabled = true;
                    Load += (sender, e) => producer.Start();
        
                }
        
                private void MyHandler(object sender, int data)
                {
                    Invoke(new Action(() =>
                    {
        
                    }));
                }
        
        }
        }
              
            class Producer
            {
                public event EventHandler<int> YSeriesEvent;
                private Thread thread;
                public int Data;
                private Chart chart;
                public Producer(Chart chart)
                {
                    this.chart = chart;
                    thread = new Thread(new ThreadStart(this.Work));
                    thread.IsBackground = true;
                    thread.Name = "My Worker";
                }
        
                public void Start()
                {
                    thread.Start();
                }
        
                private void Work()
                {
        
                    using (var channel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create(),
                           MyoErrorHandlerDriver.Create(MyoErrorHandlerBridge.Create()))))
                    {
                        using (var hub = Hub.Create(channel))
                        {
                            hub.MyoConnected += (sender, e) =>
                            {
                                Console.WriteLine($"Myo connected, handle: {e.Myo.Handle}");
                                e.Myo.Vibrate(VibrationType.Short);
                                e.Myo.EmgDataAcquired += Myo_EmgDataAcquired;
                                e.Myo.SetEmgStreaming(true);
                                YSeriesEvent?.Invoke(this, Data);
        
                            };
                            channel.StartListening();
                            while (true) { }
                        }
                    }
                }
                private void Myo_EmgDataAcquired(object sender, EmgDataEventArgs e)
                {
        
                    Data = e.EmgData.GetDataForSensor(3);
                    Console.WriteLine(Data);
                    chart.Invoke(new Action(() =>
                    {
                        for (int i = 0; i < 8; i++)
                            chart.Series[i].Points.AddY(e.EmgData.GetDataForSensor(i));
                    }
                    ));
        
                }
        
                private void returnData()
                {
                    chart.Series[0].Points.AddY(Data);
                    Console.WriteLine(Data);
                }
            }
        }
