    var startTimeSpan = TimeSpan.Zero;
    var periodTimeSpan = TimeSpan.FromHours(1);
    
    var timer = new System.Threading.Timer((e) =>
    {
    	YourPullingMethod();
    }, null, startTimeSpan, periodTimeSpan);
