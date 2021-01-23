    using System.Timers;
    
    timer = new System.Timers.Timer();
    timer.Interval = 100;//miliseconds
    timer.Elapsed += Update;
    timer.Start();     
    private void Update(object sender, ElapsedEventArgs e) {
    
    }
