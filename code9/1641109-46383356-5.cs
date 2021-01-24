    private static HttpClient _client = new HttpClient();
    public void ProcessDownloads(IEnumerable<string> uris, int concurrentDownloads)
    {
        var downloadData = new ActionBlock<string>(async uri =>
        {
            var response = await _client.GetAsync(uri); //GetAsync is a thread safe method.
            //do something with response here.
        }, new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = concurrentDownloads});
        
        foreach (var uri in uris)
        {
           downloadData.Post(uri);
        }
        downloadData.Complete();
        downloadData.Completion.Wait();
    }
