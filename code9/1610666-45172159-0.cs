    var ageIncrementor = new AgeIncrementor();
    Console.WriteLine("Age is {0}", ageIncrementor.Age);
    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 5; i++)
    {
        tasks.Add(ageIncrementor.IncrementAge());
    }
	Task.WaitAll(tasks.ToArray());
    ageIncrementor.Complete();
    Console.WriteLine("Completed");
    Console.WriteLine("Final Age is {0}", ageIncrementor.Age);
    Console.ReadKey();
