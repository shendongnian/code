    using System.Timers;
    Timer timer = new Timer(500);
    timer.Elapsed += (sender, e) => { ChangedData(); };
    timer.Start();
    // to stop the Timer
    timer.Stop();
