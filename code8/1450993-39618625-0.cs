    private static void Main(string[] args)
    {
      var jobs = new ActionBlock<JobBase>(x => x.Execute());
      jobs.Add(new Job1());
      jobs.Add(new Job2());
      jobs.Complete();
      Console.WriteLine("Starting Wait");
      Task.WaitAll(jobs.Completion.Wait()); // only using Wait because this code is in Main
      Console.WriteLine("Finished");
      Console.ReadKey();
    }
