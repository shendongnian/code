    private async Task Test()
    {
      var tasks = new List<Task>();
      for (int i = ids.first; i <= ids.last; i++)
      {
        tasks.Add(/* Do stuff */);
        await WaitList(tasks, 30);
      }
    }
    private async Task WaitList(IList<Task> tasks, int maxSize)
    {
      while (tasks.Count > maxSize)
      {
        var completed = await Task.WhenAny(tasks).ConfigureAwait(false);
        tasks.Remove(completed);
      }
    }
