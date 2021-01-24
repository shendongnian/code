    public async Task ItemCheckAsync<T>(IList<T> items, int id)
    {
      var tasks = items.Select(current => PostDataAsync(current, id));
      await Task.WhenAll(tasks);
    }
    public async Task PostDataAsync<T>(T obj, int id)
