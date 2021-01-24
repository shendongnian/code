     using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.IO.Ports;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace chart
    {
        public partial class Form1 : Form
        {
            string s;
            int InputData = 0;
            private delegate void CanIJust();
            Series series = new Series();
            private List<int> _valuelist;
            private Thread _thread;
            private CanIJust _DoIt;
            private Random _ran;
            private int _interval;
            private List<double> _timelist;
            private List<int> _customValueList;
            SerialPort ComPort = new SerialPort();
            int sfs = 0;
            string temp = "";
            string temp1 = "";
    
            public Form1()
            {
                InitializeComponent();
                chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                chart1.Series[0].XValueType = ChartValueType.Time;
                chart1.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Seconds;
                chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                chart1.ChartAreas[0].AxisX.Interval = 0;
                _valuelist = new List<int>();
                _ran = new Random();
                _interval = 500;
                tbupdateinterval.Text = "500";
                GoBoy();
                _timelist = new List<double>();
                _customValueList = new List<int>();
            }
    
    
    
            private void GetInfoPorts()
            {
                try
                {
                    string[] ArrayComPortsNames = null;
                    int index = -1;
                    string ComPortName = null;
                    cboPorts.Items.Clear();
                    cboBaudRate.Items.Clear();
                    cboStopBits.Items.Clear();
                    cboParity.Items.Clear();
                    cboHandShaking.Items.Clear();
                    //Com Ports
                    ArrayComPortsNames = SerialPort.GetPortNames();
                    do
                    {
                        index += 1;
                        cboPorts.Items.Add(ArrayComPortsNames[index]);
    
    
                    } while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));
                    Array.Sort(ArrayComPortsNames);
    
                    if (index == ArrayComPortsNames.GetUpperBound(0))
                    {
                        ComPortName = ArrayComPortsNames[0];
                    }
                    //get first item print in text
                    cboPorts.Text = ArrayComPortsNames[0];
                    //Baud Rate
                    cboBaudRate.Items.Add(115200);
                    cboBaudRate.Items.Add(300);
                    cboBaudRate.Items.Add(600);
                    cboBaudRate.Items.Add(1200);
                    cboBaudRate.Items.Add(2400);
                    cboBaudRate.Items.Add(9600);
                    cboBaudRate.Items.Add(14400);
                    cboBaudRate.Items.Add(19200);
                    cboBaudRate.Items.Add(38400);
                    cboBaudRate.Items.Add(57600);
                    cboBaudRate.Items.ToString();
                    //get first item print in text
                    cboBaudRate.Text = cboBaudRate.Items[0].ToString();
                    //Data Bits
                    cboDataBits.Items.Add(8);
                    cboDataBits.Items.Add(7);
                    //get the first item print it in the text 
                    cboDataBits.Text = cboDataBits.Items[0].ToString();
    
                    //Stop Bits
                    cboStopBits.Items.Add("One");
                    cboStopBits.Items.Add("OnePointFive");
                    cboStopBits.Items.Add("Two");
                    //get the first item print in the text
                    cboStopBits.Text = cboStopBits.Items[0].ToString();
                    //Parity 
                    cboParity.Items.Add("None");
                    cboParity.Items.Add("Even");
                    cboParity.Items.Add("Mark");
                    cboParity.Items.Add("Odd");
                    cboParity.Items.Add("Space");
                    //get the first item print in the text
                    cboParity.Text = cboParity.Items[0].ToString();
                    //Handshake
                    cboHandShaking.Items.Add("XOnXOff");
                    cboHandShaking.Items.Add("None");
                    cboHandShaking.Items.Add("RequestToSend");
                    cboHandShaking.Items.Add("RequestToSendXOnXOff");
                    //get the first item print it in the text 
                    cboHandShaking.Text = cboHandShaking.Items[0].ToString();
    
    
                }
                catch
                {
                    MessageBox.Show("خطا در گرفتن اطلاعات پورت");
                }
            }
            private void GoBoy()
            {
                _DoIt += new CanIJust(AddData);
                DateTime now = DateTime.Now;
                chart1.ChartAreas[0].AxisX.Minimum = now.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(10).ToOADate();
                _thread = new Thread(new ThreadStart(ComeOnYouThread));
                _thread.Start();
    
            }
            private void ComeOnYouThread()
            {
                while (true)
                    try
                    {
                        chart1.Invoke(_DoIt);
                        Thread.Sleep(_interval);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Exception:" + e.ToString());
                    }
            }
            private void AddData()
            {
                DateTime now = DateTime.Now;
                InputData = ComPort.ReadByte();
    
    
                object firstByte = InputData;
    
                if (ComPort.IsOpen == true)
                {
    
    
                    s = Convert.ToString(Convert.ToChar(firstByte));
                    temp1 += s;
                    lock (firstByte)
                    {
                        if (Convert.ToInt32(firstByte) == 13)
                        {
    
                            temp = temp1;
                            temp1 = "";
                            ComPort.DiscardInBuffer();
                            ComPort.DiscardOutBuffer();
                            _valuelist.Add(Convert.ToInt32(temp));
                            chart1.ResetAutoValues();
                            if (chart1.Series[0].Points.Count > 0)
                            {
                                while (chart1.Series[0].Points[0].XValue < now.AddSeconds(-5).ToOADate())
                                {
                                    chart1.Series[0].Points.RemoveAt(0);
                                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                                    chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(5).ToOADate();
                                }
                            }
                            chart1.Series[0].Points.AddXY(now.ToOADate(), _valuelist[_valuelist.Count - 1]);
                            chart1.Invalidate();
                        }
                    }
    
                }
            }
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);
                if (_thread != null)
                    _thread.Abort();
            }
    
    
            private void btn_2D_Click_1(object sender, EventArgs e)
            {
                btn_2D.Enabled = false;
                btn_3D.Enabled = true;
                chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
    
            private void btn_3D_Click_1(object sender, EventArgs e)
            {
                btn_2D.Enabled = true;
                btn_3D.Enabled = false;
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
    
            private void btn_add_Click(object sender, EventArgs e)
            {
                _customValueList.Add(_ran.Next(0, 100));
                _timelist.Add(DateTime.Now.ToOADate());
                updatesecondChart();
            }
            private void updatesecondChart()
            {
                chart2.Series[0].Points.AddXY(_timelist[_timelist.Count - 1], _customValueList[_customValueList.Count-1]);
                chart2.Invalidate();
            }
    
            private void btn_serialize_Click(object sender, EventArgs e)
            {
    
            }
    
            private void btn_updateInterval_Click(object sender, EventArgs e)
            {
                int interval = 0;
                if (int.TryParse(tbupdateinterval.Text, out interval))
                {
                    if (interval > 0)
                        _interval = interval;
                    else
                        MessageBox.Show("بازه زمانی باید بیشتر از 0 باشند");
                }
                else
                {
                    MessageBox.Show("I nappropriate Data.");
                }
            }
    
            private void btnGetSerialPorts_Click(object sender, EventArgs e)
            {
                GetInfoPorts();
            }
    
            private void btnPortState_Click(object sender, EventArgs e)
            {
                //if (sfs == 1)
                //{
                    try
                    {
                        if (btnPortState.Text == "ارتباط با دستگاه")
                        {
                            temp1 = "";
                            temp = "";
                            btnPortState.Text = "قطع ارتباط با دستگاه";
                            ComPort.PortName = Convert.ToString(cboPorts.Text);
                            ComPort.BaudRate = Convert.ToInt32(cboBaudRate.Text);
                            ComPort.DataBits = Convert.ToInt16(cboDataBits.Text);
                            ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
                            ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
                            ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
                            ComPort.Open();
                            AddData();
    
                        }
                        else if (btnPortState.Text == "قطع ارتباط با دستگاه")
                        {
                            btnPortState.Text = "ارتباط با دستگاه";
                            ComPort.Close();
    
                        }
                    }
                    catch
                    {
                        btnPortState.Text = "ارتباط با دستگاه";
                        ComPort.Close();
                        MessageBox.Show("خطا در انجام عملیات");
                    }
                }
                //else
                //{
                //    MessageBox.Show("برای ذخیزه فایل محلی را انتخاب کنید");
                //}
            //}
    
            private void CmbPalette_SelectedIndexChanged_1(object sender, EventArgs e)
            {
                chart1.Palette = (ChartColorPalette)CmbPalette.SelectedIndex;
            }
    
            private void CmbChartType_SelectedIndexChanged(object sender, EventArgs e)
            {
                 series.ChartType = (SeriesChartType)CmbChartType.SelectedIndex;
            }
        }
    }
