    async Task Add(Item item) { ... }
    async Task YourMethod()
    {
        var tasks = new List<Task>();
        foreach (var item in collection)
        {
            tasks.Add(Add(item));
        }
        // do any work you need
        Console.WriteLine("Working...");
        // then ensure the tasks are done
        await Task.WhenAll(tasks);
        
        // and flush them out
        await Flush();
    }
