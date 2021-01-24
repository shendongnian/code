    var cts = new CancellationTokenSource();
    cts.CancelAfter(TimeSpan.FromSeconds(30));
    
    var httpClient = new Windows.Web.Http.HttpClient();
    var resourceUri = new Uri("http://www.contoso.com");
    
    try
    {
        var response = await httpClient.GetAsync(resourceUri).AsTask(cts.Token);
    }
    catch (TaskCanceledException ex)
    {
        // Handle request being canceled due to timeout.
    }
    catch (Exception ex)
    {
        // Handle other possible exceptions.
    }
