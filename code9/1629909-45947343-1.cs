    Stopwatch stopwatch;
    public Form1()
    {
        InitializeComponent();
    
        stopwatch = new Stopwatch();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        // do nothing
    }
    
    private void buttonStart_Click(object sender, EventArgs e)
    {
        stopwatch.Start();
    }
    private void buttonStop_Click(object sender, EventArgs e)
    {
        stopwatch.Stop();
    }
    private void buttonReset_Click(object sender, EventArgs e)
    {
        stopwatch.Reset();
    }
    
    private void timerStopwatch_Tick(object sender, EventArgs e)
    {
        timerDraw();
    }
    private void timerDraw()
    {
        labelMinutes.Text = String.Format("{0:00}", stopwatch.Elapsed.Minutes);
        labelSeconds.Text = String.Format("{0:00}", stopwatch.Elapsed.Seconds);
        labelMSeconds.Text = String.Format("{0:000}", stopwatch.Elapsed.Milliseconds);
    }
