    var scheduleLoopAction = new Action<int, int>((int hour, int minute) =>
    {
        while (true)
        {
            var now = DateTime.Now;
            var schedule = new DateTime(now.Year, now.Month, now.Day, hour, minute, 00);
            if (schedule < now) schedule = schedule.AddDays(1);
            System.Threading.Thread.Sleep(schedule.Subtract(now));
            System.Diagnostics.Process.Start("sample.exe");
        }
    });
    ((new System.Threading.Thread(() => { scheduleLoopAction(4, 0); }))).Start();
    ((new System.Threading.Thread(() => { scheduleLoopAction(1, 0); }))).Start();
