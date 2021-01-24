    public async Task<ActionResult> Index()
    {
      await SchedulerHttpClient.Initialize.Value.ConfigureAwait(false);
      try
      {
        await MakeARMRequests().ConfigureAwait(false);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.GetBaseException().Message);
      }
      return View();
    }
