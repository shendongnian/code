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
        
       DisposeTmr();
       return 0;
    }
    
    private static void DisposeTmr() 
    {
        myTimer.Stop();
        myTimer.Dispose();
    }
    private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)       
    {
        DisposeTmr();
        Environment.Exit(0);
    }
