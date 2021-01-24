    class Program
    {
      public async Task RunLoop()
      {
        while (true)
        {
          wcM = new WeatherClientManager();
          await wcM.MainLoop();
        }
      }
    }
