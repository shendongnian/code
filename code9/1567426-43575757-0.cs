    static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    
    public static int Main(string[] args)
    {
       // Do some stuff
       Console.WriteLine("Press any key to close this window.");
    
       myTimer.Tick += new EventHandler(TimerEventProcessor);
       myTimer.Interval = 5000;
       myTimer.Start();
    
       while (!Console.KeyAvailable)
       {
            Application.DoEvents();
            Thread.Sleep(250);
       }
    
       return 0;
    }
    
    
    private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)       
    {
        myTimer.Stop();
        Environment.Exit(0);
    }
