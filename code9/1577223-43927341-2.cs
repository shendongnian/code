    private void Button_Ten_Sec_Click(object sender, EventArgs e)
    {
        // Add ten seconds to our clock
        countdownClock += TimeSpan.FromSeconds(10);
        // Start the timer if it's stopped
        if (!timer.Enabled) timer.Start();
    }
    private void Button_One_Min_Click(object sender, EventArgs e)
    {
        // Add one minute to our clock
        countdownClock += TimeSpan.FromMinutes(1);
        // Start the timer if it's stopped
        if (!timer.Enabled) timer.Start();
    }
    private void Button_Ten_Min_Click(object sender, EventArgs e)
    {
        // Add ten minutes to our clock
        countdownClock += TimeSpan.FromMinutes(10);
        // Start the timer if it's stopped
        if (!timer.Enabled) timer.Start();
    }
