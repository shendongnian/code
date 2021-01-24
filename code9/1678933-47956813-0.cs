    protected System.Timers.Timer MonitorTimer = new System.Timers.Timer();
    public void Initialize()
    {
        MonitorTimer.Elapsed += new ElapsedEventHandler(UpdateEvent);
        MonitorTimer.Interval = 1000;
        MonitorTimer.Enabled = true;
    }
    protected object TimerLock = new object();
    public void UpdateEvent(object source, ElapsedEventArgs e)
    {
        lock (TimerLock)
        {
        	doc = (mshtml.HTMLDocument)wbProfile.Document;
            // What you are looking for that only appears later. -->
        	if(doc.body.innerHTML.toString().IndexOf("foo") != -1) 
        	{
        		// Do something useful..
        	}
        }
    }
