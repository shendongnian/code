    class Program
    {
      static void Main(string[] args)
      {
        while (true)
        {
          DoWork();
          Console.WriteLine("Task delayed...");
          Task.Sleep(3000);
        }
      }
      public static void DoWork()
      {
        //Do some work
        Console.WriteLine("Work Completed.");
      }
    }
