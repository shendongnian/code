    public static async Task LoadAsync(params string[] urls)
    {
      var tasks = urls.Select(url => WriteToDisk(Build(url)));
      await Task.WhenAll(tasks);
    }
