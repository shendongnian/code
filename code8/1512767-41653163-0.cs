    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace serial_port_with_events_attempt_4
    { 
    public partial class Form1 : Form
     {
        string RxString;
        int RxRead;
        int i;
        int j;
        int RxDec1;
        int RxDec2;
        int RxDec3;
        float RxFloat;
        float RxFloat2;
        string locnString = "Unknown";
        DateTime deleteDate;
        string deleteDateString;
        string testString;
   
        public Form1()
        {
            InitializeComponent();
            deleteDate = DateTime.Today;
            deleteDate = deleteDate.AddDays(-7);
            deleteDateString = deleteDate.ToString();
            textBox1.AppendText(deleteDateString);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM8";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
            if (serialPort1.IsOpen)
            {
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                  //textBox1.ReadOnly = false;
            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                //textBox1.ReadOnly = true;
            }
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            for (j = 0; j<23 ; j++)
            {
                    if (serialPort1.BytesToRead > 0)
                    {
                        RxRead = serialPort1.ReadByte();
                        this.Invoke(new EventHandler(DisplayText));
                    }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void DisplayText(object sender, EventArgs e)
        {
              if (RxRead == 126)
            {
                //textBox1.AppendText(Environment.NewLine);
                i = 0;
            }
            
            if (i< 23)
            {
                if (i == 13)
                {
                    testString = RxRead.ToString();
                    textBox1.AppendText(testString);
                    if (RxRead == 82) // 82 in this position means that the temp sensor is the low range one (R1L)
                    { 
                       //textBox1.AppendText("Temperature in Nick's office = ");
                       locnString = ("Nicks office");
                    }
                    if (RxRead == 195) // 195 in this position means that the temp sensor is the high range one (R1H)
                    {
                        //textBox1.AppendText("Temperature in Nick's office = ");
                        locnString = ("Sitting Room");
                    }
                }
                if (i == 17)
                {
                    RxDec1 = RxRead - 48; // Read the tens unit
                }
                if (i == 18)
                {
                    RxDec2 = RxRead - 48; // Read the units
                }
                if (i == 20)
                {
                    RxDec3 = RxRead - 49; // read the decimal
                }
                if (i == 22)
                {
                    RxFloat = ((RxDec1 * 10) + RxDec2);
                    RxFloat2 = RxDec3;
                    RxFloat2 = RxFloat2 / 10;
                    RxFloat = RxFloat + RxFloat2;
                    // Frig about to get the reads in the right format and added together
    
                    RxString = RxFloat.ToString();
                    if (RxFloat < 30 && RxFloat >10)
                    {
                    //textBox1.AppendText(RxString);
                        if (locnString == "Nicks office")
                        {
                          button1.Text = RxString;
                        }
                        if (locnString == "Sitting Room")
                        {
                            button2.Text = RxString;
                        }
                    
                    // Put the value in the main text box if it is not corrupt, (checking if the range is reasonable
                    temperature1DataSetTableAdapters.Temp1TableAdapter temp1tableadapter = new temperature1DataSetTableAdapters.Temp1TableAdapter();
                    temp1tableadapter.Insert(DateTime.Now, RxFloat, locnString);
                    // Add a new line into the temperature database
                    }
                    deleteDate = DateTime.Today;
                    deleteDate = deleteDate.AddDays(-7);
                    deleteDateString = deleteDate.ToString();
                    textBox1.Clear();
                    textBox1.AppendText(deleteDateString);
                    temperature1DataSetTableAdapters.TempTableAdapter temp2tableadapter = new temperature1DataSetTableAdapters.TempTableAdapter();
                    temp2tableadapter.DeleteTempQuery(deleteDate);
                    //textBox1.AppendText("BreakpointA");
                    textBox1.AppendText(testString);
                    // Delete any old data.
                     // TODO Doesn't seem to be working.  Don't understand why not.  The code gets to here as Breakpoint A gets triggered
                    this.tempTableAdapter.Fill(this.temperature1DataSet.Temp);
                    chart1.DataBind();
                    // These two lines refresh the chart.  Took me a long time to figure this out.  Basically, you have to 
                    // rerun the query and then run the DataBind method to update the chart control.
                    // Good article on table adapters http://msdn.microsoft.com/en-us/library/bz9tthwx%28VS.80%29.aspx
                    //** test code for second chart.
                    this.tempSensor2AdapterTableAdapter.tempSensor2Fill(this.temperature1DataSet.tempSensor2Adapter);
                    chart2.DataBind();
                }
             }
                i=i+1;
         }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'temperature1DataSet.tempSensor2Adapter' table. You can move, or remove it, as needed.
            this.tempSensor2AdapterTableAdapter.tempSensor2Fill(this.temperature1DataSet.tempSensor2Adapter);
            // TODO: This line of code loads data into the 'temperature1DataSet.Temp' table. You can move, or remove it, as needed.
            this.tempTableAdapter.Fill(this.temperature1DataSet.Temp);
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "{0:dd/MM H:mm}";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:dd/MM H:mm}";
        }
        }
    }
