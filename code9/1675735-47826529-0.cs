    bool isRunning = true;
    bool signalHasBeenFalse = true;
    private void WorkThreadFunction()
    {
        while (isRunning)
        {
             if (ethernetIPforSLCMicroCom1.Read("B3:254/1") == "True" && hasBeenFalse )
            {
                signalHasBeenFalse = false;
                stopWatch = Stopwatch.StartNew();
                int isTriggered;
                Int32.TryParse(trigger, out isTriggered);
                timer1.Start();
                Thread.Sleep(10);
                serialcheck();
                System.GC.Collect();
            }
            if ( ethernetIPforSLCMicroCom1.Read("B3:254/1") != "True" ) 
            {
                signalHasBeenFalse = true;
            }
        }
    }
