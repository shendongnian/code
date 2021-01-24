    class ThreadTest
    {
      static void Main()
      {
        Task t = Task.Run(() => Write(5));
    
        // Simultaneously, do something on the main thread.
        for (int i = 0; i < 1000; i++) Console.Write ("x");
        t.wait();
      }
    
      static double Write(double a)
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
            return a;
        }
    }
