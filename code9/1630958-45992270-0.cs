    class Program
    {
      public static ManualResetEvent Shutdown = new ManualResetEvent(false);
    
      static void Main(string[] args)
      {
        Task.Run(() =>
        {
          Console.WriteLine("Waiting in other thread...");
          Thread.Sleep(2000);
          Shutdown.Set();
        });
        
        Console.WriteLine("Waiting for signal");
        Shutdown.WaitOne();
        
        Console.WriteLine("Resolved");
      }
    }
