    static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        var t = sender as System.Timers.Timer;
        while (ActiveContracts.Any())
        {
            var item = ActiveContracts[0];
            if (item.ExpirationDate > DateTime.Now)
            {
                break;
            }
            item.MarkAsExpired();
            ActiveContracts.RemoveAt(0);
        }
        if (ActiveContracts.Any())
        {
            // specially when debugging, the time difference can lead to a negative new interval - don't assign directly
            var nextInterval = (ActiveContracts[0].ExpirationDate - DateTime.Now).TotalMilliseconds;
            t.Interval = nextInterval > 0 ? nextInterval : 1;
            t.Start();
        }
        else
        {
            t.Stop();
        }
    }
