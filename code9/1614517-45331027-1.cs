    public doeverysecond()
    {
        {   
            System.Timers.Timer mytimer = new System.Timers.Timer();
            mytimer.Elapsed += new ElapsedEventHandler(customfn);
            mytimer.Interval = 1000;
        }
     }
        
