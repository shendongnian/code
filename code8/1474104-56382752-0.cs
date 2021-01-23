    int interval = Timeout.Infinite;
    int timerCount = 0;
    Timer t;
    void Main()
    {
    	interval = 100;
    	t = new Timer(OnTick, null, 0, interval);
    }
    
    void OnTick(object state)
    {
    	timerCount++;
    	if (timerCount == 3)
    	{
    		interval = Timeout.Infinite;
    		t.Change(Timeout.Infinite, interval);
    	}
    
    	$"Timer count: {timerCount}. Timer is running: {IsTimerRunning()}.".Dump();
    }
    
    bool IsTimerRunning()
    {
    	return interval != Timeout.Infinite;
    }
    
    /* Output:
    Timer count: 1. Timer is running: True.
    Timer count: 2. Timer is running: True.
    Timer count: 3. Timer is running: False.
    */
