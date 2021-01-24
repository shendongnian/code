    private bool flag = true;
    public void LoopReadHoistingTest()
    {
        Task.Run(() => { flag = false; });
        while (flag)
        {
          // Do nothing
        }
    }
