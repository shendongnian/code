    public void Ticker()
       {
             System.Timers.Timer aTimer = new System.Timers.Timer(); 
             aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
             aTimer.Interval = 1000;
             aTimer.Enabled = true;
        }
        void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (days < 28)
                days++;
            else
                days = 0;
            if (days == 28 && months < 4)
                months++;
            else if (days == 28 && months == 4)
            {
                months = 0;
                years++;
            }
        }
