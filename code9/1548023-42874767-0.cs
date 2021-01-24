    protected void Timer1_Tick(object sender, EventArgs e)
    {
        String DateTimeFuture = DateTime.Now.AddHours(2).ToString(); // NOW + 2 HOURS
        DateTime NeededByDateTime = DateTime.Parse(DateTimeFuture);
        TimeSpan time1 = new TimeSpan();
        time1 = NeededByDateTime - DateTime.Now; // NOW + 2 HOURS - NOW = 2 HOURS
        if ((time1.Hours == 0) && (time1.Minutes == 0) && (time1.Seconds == 0))
        {
            Label1.Text = "Time Expired!";
        }
        else
        {
            string countDown = string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds til launch.", time1.Days, time1.Hours, time1.Minutes, time1.Seconds);
            Label1.Text = countDown.ToString();
        }
    }
