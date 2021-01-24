    static void Work(IEnumerable<int> ints) {
      var sum = ints.Sum();
      Thread.Sleep(sum);
      Console.WriteLine(ints.Sum());
    }
  
    public static void Main (string[] args) {
      var inputs = from i in Enumerable.Range(0, 100)
                   select i + i;
      var batches = inputs.Batch(8);
      var tasks = from batch in batches
                  select Task.Run(() => Work(batch));
      Task.WaitAll(tasks.ToArray());
    }
