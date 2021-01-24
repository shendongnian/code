    public Task Execution { get; private set; } = StartAsync();
    private List<string> _requests = new List<string>();
    private string _currentRequest;
    private async Task StartAsync()
    {
      while (true)
      {
        if (_requests.Count != 0)
        {
          _currentRequest = _requests[0];
          _request.RemoveAt(0);
          SomeOtherMethodWithTheActualCode(_currentRequest); // TODO: error handling
          _currentRequest = null;
        }
        await Task.Delay(100);
      }
    }
    protected void Foo(String arg)
    {
      var index = _requests.IndexOf(arg);
      if (index != -1)
        _requests.RemoveRange(index, _requests.Count - index);
      else if (arg == _currentRequest)
        _requests.Clear();
      _requests.Add(arg);
    }
