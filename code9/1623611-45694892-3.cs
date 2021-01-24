    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    timer.Interval = 1000;
    timer.Tick += Timer_Tick;
    timer.Start();
    private void Timer_Tick(object sender, EventArgs e)
    {
        // here the same code as above    
    }
