    static System.Threading.Timer myTimer;
    
    public static int Main(string[] args)
    {
       // Do some stuff
       Console.WriteLine("Press any key to close this window.");
  
       myTimer = new System.Threading.Timer(TimerCallback, null, 5000, Timeout.Infinite);
       while (!Console.KeyAvailable)
       {          
            Thread.Sleep(250);
       }
        
       DisposeTmr();
       return 0;
    }
    
    private static void DisposeTmr() 
    {
        if (myTimer != null)
        {
            myTimer.Dispose();
        }
    }
    private static void TimerCallback(Object myObject)       
    {
        DisposeTmr();
        Environment.Exit(0);
    }
