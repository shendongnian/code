    public static void PrintCount()
    {
      Console.WriteLine("Step 2");
      for (var i = 1; i <= 1000; i++)
      {
        Thread.Sleep(1000);
        Console.WriteLine(i);
      }
    }
    static async Task Steps()
    {
      var task = Task.Run(() => PrintCount());
      Console.WriteLine("Step 1");
      await task;
    }
