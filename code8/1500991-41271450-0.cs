    using System.Collections.Concurrent;
    private static void testMethod()
    {
      BlockingCollection<Action> myActionQueue = new BlockingCollection<Action>();
      var consumer = Task.Run(() =>
      {
        foreach(var item in myActionQueue.GetConsumingEnumerable())
        {
          item(); // Run the task
        }// Exits when the BlockingCollection is marked for no more actions
      });
      // Add some tasks
      for(int i = 0; i < 10; ++i)
      {
        int captured = i; // Imporant to copy this value or else
        myActionQueue.Add(() =>
        {
          Console.WriteLine("Action number " + captured + " executing.");
          Thread.Sleep(100);  // Busy work
          Console.WriteLine("Completed.");
        });
        Console.WriteLine("Added job number " + i);
        Thread.Sleep(50);
      }
      myActionQueue.CompleteAdding();
      Console.WriteLine("Completed adding tasks.  Waiting for consumer completion");
      consumer.Wait();  // Waits for consumer to finish
      Console.WriteLine("All actions completed.");
    }
