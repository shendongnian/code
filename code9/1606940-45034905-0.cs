    public void DoWork(CancellationToken token)
    {
      token.ThrowIfCancellationRequested();
      using (token.Register(() => _thirdPartyService.StopWork()))
        _thirdPartyService.DoLongWork();
    }
