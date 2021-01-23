    //The next code simulates data changes every 500 ms
    Timer = new Timer
    {
    	Interval = 1000
    };
    Timer.Tick += TimerOnTick;
    R = new Random();
    Timer.Start();
    
    //another timer
    SecondTimer = new Timer() { Interval = 2000 };
    SecondTimer.Enabled = true;
    SecondTimer.Tick += SecondTimer_Tick;
