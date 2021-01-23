    private static async Task DoBothAsync()
    {
      await Task.Run(() => Console.WriteLine("Bar"));
      Console.WriteLine("Baz");
    }
    public static void Main(string[] args)
    {
      Task FooTask = DoBothAsync();
      FooTask.Wait();
      Console.WriteLine("Press Enter To Exit.");
      Console.ReadLine();
    }
