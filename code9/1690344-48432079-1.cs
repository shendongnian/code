    // Return Task, not void
    // Name async methods accordingly
    private async Task StartAsync()
    {
      Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} - Started processing.");
      Task task2 = null;
      for (int i = 0; i < 10; i++)
      {
         // We cannot do Step2Async until Step1Async's task 
         // completes, so await it.
         string result = await Step1Async(i);
         // We can't run a new Step2Async until the old one is done:
         if (task2 != null) {
           await task2;
           task2 = null;
         }
         // Now run a new Step2Async:
         task2 = Step2Async(result);
         // But *do not await it*.  We don't care if a new Step1Async
         // starts up before Step2Async is done.
      }
      // Finally, don't complete StartAsync until any pending Step2 is done.
      if (task2 != null) {
        await task2;
        task2 = null;
      }
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
