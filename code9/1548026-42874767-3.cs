    private DateTime NeededByDateTime = DateTime.Now.AddHours(2); //.., or whatever you want 
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        TimeSpan time1 = NeededByDateTime - DateTime.Now;
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
