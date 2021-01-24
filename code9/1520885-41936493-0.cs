    // Constructor
    public Form1()
    {
        InitializeComponent();
        // Format
        this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "ss.fff";
        // this sets the type of the X-Axis values
        chart1.Series[0].XValueType = ChartValueType.DateTime;
        timer1.Start();
    }
    int i = 0;
    List<DateTime> TimeList = new List<DateTime>();
    private void timer1_Tick(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        TimeList.Add(now);
        chart1.Series[0].Points.AddXY(now, Math.Sin(i / 60.0));
        i+=2;
    }
