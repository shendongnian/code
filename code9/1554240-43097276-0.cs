      public async Task DelayMe()
      {
        await Task.Delay(1000);
        await MoreAsyncThings();
      }
      Task T1 { get; set; }
      public async Task CreateAndAwaitAsync()
      {
        T1 = DelayMe();
        await T1;
      }
