     System.Timers.Timer timer1 = new System.Timers.Timer();
     timer1.Interval = 1000; //time after which you want to clear datagrid
     timer1.Start();
     timer1.Elapsed += TimerTick;
    
