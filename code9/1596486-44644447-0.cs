    public static Timer peekTimer = new Timer (SECOND * PEEK_TIME);
    static void Main (string [] args)
    {
    const int PEEK_TIME = 5;
    const int SECOND = 1000;    
    Console.WriteLine ("Timer started...");
    peekTimer.Interval = new TimeSpan(0, 0, 0, 0, SECOND * PEEK_TIME);
    peekTimer.Tick += new EventHandler(onTimerTick);
    peekTimer.Start();
    
    }
    static void onTimerTick (Object source, System.Timers.ElapsedEventArgs e)
    {
    peekTimer.Stop();
    Console.Clear ();
    Console.WriteLine ("Timer done.");
    Console.ReadLine ();
    }
