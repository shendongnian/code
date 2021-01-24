    // Return Task, not void
    // Name async methods accordingly
    private async Task StartAsync()
    {
      Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} - Started processing.");
      List<Task> task2 = new List<Task>();
      for (int i = 0; i < 10; i++)
      {
         // We cannot do Step2Async until Step1Async's task 
         // completes, so await it.
         string result = await Step1Async(i);
         // We don't care if a new Step1Async starts before Step2Async's
         // task is done or not, so don't await.
         // However, we *do* want all the Step2Async tasks to be done
         // before StartAsync completes, so we remember them:
         task2.Add(Step2Async(result));
      }
      // We cannot complete StartAsync until all the task2's are done.
      await Task.WhenAll(task2);
      Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} - Finished processing.");
    }
    private string Step1(int i)
    {
       // TODO: CPU intensive work here
    }
    private async Task<string> Step1Async(int i) {
      // TODO: Run CPU-intensive Step1(i) on a worker thread
      // return a Task<string> representing that work, that is
      // completed when the work is done.
    }
    private void Step2(string result)
    {
      // TODO: CPU-intensive work here
    }
    private async Task Step2Async(string result) 
    {
      // TODO: Again, make a worker thread that runs Step2
      // and signals the task when it is complete.
    }
