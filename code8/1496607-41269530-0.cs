    private Task AdwordsPullDataSynchronizer(System.Timers.Timer timer)
    {
         if (!_TimerChecked)
         {
              _IsDirty = false;
              timer.Stop();
              var interval = Convert.ToDouble(Math.Abs(DateTime.Now.Second - 60));
              timer.Interval = (interval + 2) * 1000;
              timer.Start();
              _TimerChecked = true;
         }
         if (DateTime.Now.Second > 10)
         {
             _IsDirty = true;
             _TimerChecked = false;
         }
     
         //Place your interval logic here
 
         if (_IsDirty)
         {
            timer.Stop();
            var interval = Convert.ToDouble(Math.Abs(DateTime.Now.Second - 60));
            timer.Interval = (interval + 2) * 1000;
            timer.Start();
         }
         return Task.FromResult(0);
    }
 
