    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    int countdown = 30;
    // event handler of your button
    private void button1_Click(object sender, EventArgs e)
    {
        countdown = 30; // number of seconds
        timer.Interval = 1000; // one second
        timer.Tick += timer_Tick;
        timer.Start();
        button1.Enabled = false;
        // place get random code here
    }
    void timer_Tick(object sender, System.EventArgs e)
    {
        if (--countdown <= 0)
        {
            button1.Enabled = true;
            timer.Stop();
            timer.Tick -= timer_Tick;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Remaining: {0}s", countdown));
        }
    }
