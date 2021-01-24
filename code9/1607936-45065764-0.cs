    async Task LoadItems()
    {
      IEnumerable<Task> tasks = Directory.GetDirectories(somePath)
          .Select(dir => Task.Run(() =>
               new ItemViewModel(new ItemSerializer().Deserialize(dir))));
      foreach (var task in tasks)
      {
        var result = await task;
        DoSomething(result);
      }
    }
