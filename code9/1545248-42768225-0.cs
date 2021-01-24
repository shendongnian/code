    private Dictionary<Guid, TaskCompletionSource<WeatherResponse>> _weatherRequests;
    public Task<WeatherResponse> GetWeatherAsync()
    {
      var messageId = Guid.NewGuid();
      var tcs = new TaskCompletionSource<WeatherResponse>();
      _weatherRequests.Add(messageId, tcs);
      _server.SendWeatherRequest(messageId);
      return tcs.Task;
    }
    public void ObjectReceived(object data)
    {
      ...
      if (data is ServerWeatherResponse)
      {
        var tcs = _weatherRequests[data.requestId];
        _weatherRequests.Remove(data.requestId);
        tcs.SetResult(new WeatherResponse(data));
      }
    }
