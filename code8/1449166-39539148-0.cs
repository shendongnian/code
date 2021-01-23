    // member variables
    DateTime firstSchedule = DateTime.UtcNow;
    var numElapsed = 1;
    
    constructor()
    {
    	this.timerObj = new System.Timers.Timer();
    	timerObj.Interval = CalcDelta();
    	timerObj.Elapsed += timerObj_Elapsed;
    	timerObj.AutoReset = false;
    	timerObj.Start();
    }
    
    void timerObj_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        this.numElapses++;
    	this.timerObj.Interval = CalcDelta();
    	this.timerObj.Start();
    	
      	DateTime currentTime = DateTime.Now;
      	Console.WriteLine(currentTime.ToString("HH:mm:ss.fff"));
    }
    
    
    private long CalcDelta()
    {
    	DateTime nextSchedule = firstSchedule + TimeSpan.FromSeconds(numElapses * 10);
    	return (nextSchedule - DateTime.UtcNow).TotalMilliseconds;	
    }
