    private void Form1_Load(object sender, EventArgs e)
    {
        /* Set the last shutdown to the last time we were alive.. */
        Properties.Settings.Default.LastShutdown = Properties.Settings.Default.LastHeartbeat;
        this.timer1.Interval = 100;
        this.timer1.Tick += timer1_Tick;
        this.timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        Properties.Settings.Default.LastHeartbeat = DateTime.UtcNow;
        Properties.Settings.Default.Save();
    }
