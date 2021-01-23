    public Task JoinAsync()
    {
      this.IsConnected = false;
      return _ComposerTask;
    }
