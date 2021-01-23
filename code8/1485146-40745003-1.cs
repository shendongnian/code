    public async Task<object> GetSensorConfiguration(string desc)
    {
      var updateTask = UpdateTableAsync(desc);
      var getTask = GetObjectValueAsync(desc);
      await Task.WhenAll(updateTask, getTask);
      return await getTask;
    }
