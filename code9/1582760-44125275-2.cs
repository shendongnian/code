    DateTime startupTime = DateTime.Now - UpTime;
    if(Settings.LastLaunchTime < startupTime) {
        //system was restarted since the last launch, resetting location
    }
    Settings.LastLaunchTime = DateTime.Now;
    //System up time property
    TimeSpan UpTime {
        get {
            using (var uptime = new PerformanceCounter("System", "System Up Time")) {
                uptime.NextValue();       //Call this an extra time before reading its value
                return TimeSpan.FromSeconds(uptime.NextValue());
            }
        }
    }
