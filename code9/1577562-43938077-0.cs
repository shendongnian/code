    static async Task<string> PerfromTaskAction()
    {
      object[] arrObjects = new object[] { "SERVER1", "SERVER2", "SERVER3", "SERVER4" };
      var tasks = arrObjects.Select(i => Task.Run(() => HeavyOperation(i.ToString())));
      var results = await Task.WhenAll(tasks).ConfigureAwait(false);
      return string.Join("", results);
    }
