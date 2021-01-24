    private void UpdateCountdown(object source, EventArgs e) 
    {
        if (--Countdown == 0)
            ShowImage();
    }
    
    public void DoStuff()
    {
        Timer timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += UpdateCountdown;
        timer.Start();    
    }
