    var tasks = new List<Task>();
    foreach(var item in items)
      tasks.Add(ProcessItemAndLogExceptionsAsync(item));
    await Task.WhenAll(tasks);
    private static async Task ProcessItemAndLogExceptionsAsync(Item item)
    {
      try
      {
        await ProcessItemAsync(item);
      }
      catch (Exception ex)
      {
        // Log exception
      }
    }
