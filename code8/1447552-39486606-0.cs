    private PerformanceCounter cpuCounter;
    public Form1()
    {
        InitializeComponent();
        InitialiseCPUCounter();
        timer1.Start();
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        float tmp = cpuCounter.NextValue();
        textBox1.Text = String.Format("{0} %", tmp);
    }
    
    private void InitialiseCPUCounter()
    {
       cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
    }
