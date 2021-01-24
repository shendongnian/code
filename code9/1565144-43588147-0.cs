    var cts = new CancellationTokenSource();
    cts.CancelAfter(TimeSpan.FromSeconds(30));
 
    var httpClient = new System.Net.Http.HttpClient();
    var resourceUri = new Uri("http://www.contoso.com");
 
    try
    {
       HttpResponseMessage response = await httpClient.GetAsync(resourceUri, cts.Token);
    }
    catch (TaskCanceledException ex)
    {
       // Handle request being canceled due to timeout.
    }
    catch (HttpRequestException ex)
    {
       // Handle other possible exceptions.
    }
