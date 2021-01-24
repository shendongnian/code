    private void Form1_Load(object sender, EventArgs e)
    {
        timer = new System.Windows.Forms.Timer();
        timer.Interval = (int) TimeSpan.FromSeconds(1).TotalMilliseconds;
        timer.Tick += OnTimeEvent;
        DisplayTime();
    }
