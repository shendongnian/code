    public async Task GetPersonData()
    {
      var persons= queryProcessor.Process(new GetPersonsWhichNeedApiCalls());
      var watch = System.Diagnostics.Stopwatch.StartNew();
      await SearchAPI(persons);
      var elapsedMs = watch.ElapsedMilliseconds;
    }
