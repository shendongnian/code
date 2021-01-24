    private Timer myTimer; 
    public void InitTimer()
    {
        myTimer = new Timer();
        myTimer.Tick += new EventHandler(myTimer_Tick);
        myTimer.Interval = 300; // in miliseconds
        myTimer.Start();
    }
    
