    public void ProcessDownloads(IEnumerable<string> uris, int concurrentDownloads)
    {
        var downloadData = new ActionBlock<string>(async uri =>
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                //do something with response here.
            }
        }, new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = concurrentDownloads});
        
        foreach (var uri in uris)
        {
           downloadData.Post(uri);
        }
        downloadData.Complete();
        downloadData.Completion.Wait();
    }
