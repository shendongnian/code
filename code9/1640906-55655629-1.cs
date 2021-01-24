    var client = new HttpClient(
    new RetryHandler(TimeSpan.FromMinutes(1)))
    {
        Timeout = TimeSpan.FromMinutes(5)
    };
    client.PostAsync(...);
