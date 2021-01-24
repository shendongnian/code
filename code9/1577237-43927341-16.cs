    private void Button_Ten_Sec_Click(object sender, EventArgs e)
    {
        // Add ten seconds to our clock
        AddTimeToClock(TimeSpan.FromSeconds(10));
    }
    private void Button_One_Min_Click(object sender, EventArgs e)
    {
        // Add one minute to our clock
        AddTimeToClock(TimeSpan.FromMinutes(1));
    }
    private void Button_Ten_Min_Click(object sender, EventArgs e)
    {
        // Add ten minutes to our clock
        AddTimeToClock(TimeSpan.FromMinutes(10));
    }
