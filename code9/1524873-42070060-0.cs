    private async void timerPollingData_Tick(object sender, EventArgs e)
    {
      var task1 = readDevice_01();
      var task2 = readDevice_02();
      // and so on for all devices ...
      await Task.WhenAll(task1, task2, ...);
    }
    private async Task readDevice_01()
    {
      var result = await Task.Run(() => getDataDevice_01());
      // Save data
    }
    private string getDataDevice_01()
    {
      MyCustomLibrary readDevice = new MyCustomLibrary.Master();
      return readDevice.ReadHoldingRegister(... some parameters ...).ToString();                       
    }
