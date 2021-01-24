    class Program
    {
	    private static AutoResetEvent autoResetEvent;
        private static CultureInfo culture = new CultureInfo("en-gb");
	
        static void Main(string[] args)
        {
            LongRunningClass longRunningClass = new LongRunningClass();
            WaitForCancel();
        }
	
	    /// <summary>
	    /// When cancel keys Ctrl+C or Ctrl+Break are used, set the event.
	    /// </summary>
	    private static void WaitForCancel()
	    {
		    autoResetEvent = new AutoResetEvent(false);
		    Console.WriteLine("Press CTRL + C or CTRL + Break to exit...");
		    Console.CancelKeyPress += (sender, e) =>
			    {
				    e.Cancel = true;
				    autoResetEvent.Set();
			    };
		    autoResetEvent.WaitOne();
	    }
    }
