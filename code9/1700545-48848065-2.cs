    static int Work(IEnumerable<int> ints) {
      Console.WriteLine("Work on thread " + Thread.CurrentThread.ManagedThreadId);
      var sum = ints.Sum();
      Thread.Sleep(sum);
      return sum;
    }
  
    public static void Main (string[] args) {
      var inputs = from i in Enumerable.Range(0, 100)
                   select i + i;
      var batches = inputs.Batch(8);
      var tasks = from batch in batches
                  select Work(batch);
      foreach (var task in tasks.AsParallel()) {
        Console.WriteLine(task);
      }
    }
    /*
    Work on thread 6
    Work on thread 4
    56
    Work on thread 4
    184
    Work on thread 4
    Work on thread 4
    312
    440
    ...
    */
