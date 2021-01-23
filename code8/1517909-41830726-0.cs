    public static DateTime TimeSettings()
    {
    	TimeSimulation startTime = new TimeSimulation();
    	startTime.Second = 1;
    	startTime.Minute = 1;
    	startTime.Hour = 1;
    	startTime.Day = 1;
    	startTime.Month = 1;
    	startTime.Year = 2000;
    
    	return gameTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, startTime.Second);
    }
    
    public static void ShowTime()
    {
    	DateTime gameTime = TimeSettings()
    	Console.WriteLine(gameTime);
    }
