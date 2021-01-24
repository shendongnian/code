    private async void timerPollingData_Tick(object sender, EventArgs e)
    {
      var task1 = readDevice_01Async();
      var task2 = readDevice_02Async();
      // and so on for all devices ...
      await Task.WhenAll(task1, task2, ...);
    }
    private async Task readDevice_01Async()
    {
      var result = await getDataDevice_01Async();
      // Save data
    }
    private async Task<string> getDataDevice_01Async()
    {
      MyCustomLibrary readDevice = new MyCustomLibrary.Master();
      var result = await readDevice.ReadHoldingRegisterAsync(... some parameters ...);
      return result.ToString();
    }
