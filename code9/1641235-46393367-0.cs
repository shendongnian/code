    private async Task Test()
    {
      var allTasks = new List<Task>();
      foreach (var file in filesToUpload)
      {
        await WaitList(allTasks, 1000);
        allTasks.Add(UploadFileAsync(file));
      }
      await Task.WhenAll(allTasks);
    }
    private async Task WaitList(IList<Task> tasks, int maxSize)
    {
      while (tasks.Count > maxSize)
      {
        var completed = await Task.WhenAny(tasks).ConfigureAwait(false);
        tasks.Remove(completed);
      }
    } 
