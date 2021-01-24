    public ActionResult Index()
    {
      var r = Task.Run(() => LongRunner.LongRunnerInstance.DoSomethingThatTakesReallyLong())
          .GetAwaiter().GetResult();
      return View();             
    }
