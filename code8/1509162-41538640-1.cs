      Stopwatch timer = new Stopwatch();
      timer.Start();
      for (int i = 0; i < 10; i++)
      {
          a += i;
      }
 
      timer.Stop();
      Console.WriteLine($"Elapsed time: {timer.Elapsed}");
