    public static async Task<Task> RestartAsync()
    {
      var client = new Client("...");
      if (CheckApiKey(client))
        return;
      client.Stop();
      await Task.Delay(TimeSpan.FromSeconds(5));
      client.Start();
    }
