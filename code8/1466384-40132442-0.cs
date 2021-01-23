    void Application_Start(object sender, EventArgs e)
    {
    	var backgroundTimerTenMinutes = new System.Timers.Timer(600000);
    	backgroundTimerTenMinutes.Elapsed += backgroundTimerTenMinutes_Elapsed;
    }
    
    void backgroundTimerTenMinutes_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	HostingEnvironment.QueueBackgroundWorkItem(ct => DBQueryAndNotify(ct));
    }
