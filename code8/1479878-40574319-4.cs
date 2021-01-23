    PerformanceCounter cpuCounter;   
    PerformanceCounter ramCounter;
    public Form1()
    {
        InitializeComponent();
        InitializeCounters();
    }
    private void InitializeCounters()
    {
        cpuCounter = new PerformanceCounter();
        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
        cpuCounter.InstanceName = "_Total";
        ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    }
    int timeX = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {        
        float cpuUsage = 0.00F;
        cpuUsage = cpuCounter.NextValue();
        textBox1.Text = cpuUsage.ToString();
       
        float ram = ramCounter.NextValue();
        textBox2.Text = ram.ToString();
        // Your chart stuff
        //chart1.Series["CPU Usage"].Points.AddXY(timeX, (int)cpuUsage);
        //chart2.Series["Memory Use"].Points.AddXY(timeX, (int)ram);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        timer1.Start();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        timer1.Stop();
    }
