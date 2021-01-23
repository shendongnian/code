    var scheduleLoopAction = new Action<int, int, string>((int hour, int minute, string processName) =>
    {
        while (true)
        {
            var now = DateTime.Now;
            var schedule = new DateTime(now.Year, now.Month, now.Day, hour, minute, 00);
            if (schedule < now) schedule = schedule.AddDays(1);
            System.Threading.Thread.Sleep(schedule.Subtract(now));
            System.Diagnostics.Process.Start(processName);
        }
    });
    ((new System.Threading.Thread(() => { scheduleLoopAction(4, 0, "sample.exe"); }))).Start();
    ((new System.Threading.Thread(() => { scheduleLoopAction(1, 0, "sample2.exe"); }))).Start();
