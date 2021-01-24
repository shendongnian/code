    private static HttpClient _client = new HttpClient();
    public async Task<List<MyClass>> ProcessDownloads(IEnumerable<string> uris, 
                                                      int concurrentDownloads)
    {
        var result = new List<MyClass>();
        var downloadData = new TransformBlock<string, string>(async uri =>
        {
            return await _client.GetStringAsync(uri); //GetStringAsync is a thread safe method.
        }, new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = concurrentDownloads});
        var processData = new TransformBlock<string, MyClass>(
              json => JsonConvert.DeserializeObject<MyClass>(json), 
              new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded});
        var collectData = new ActionBlock<MyClass>(
              data => result.Add(data)); //When you don't specifiy options dataflow processes items one at a time.
        //Set up the chain of blocks, have it call `.Complete()` on the next block when the current block finishes processing it's last item.
        downloadData.LinkTo(processData, new DataflowLinkOptions {PropagateCompletion = true});
        processData.LinkTo(collectData, new DataflowLinkOptions {PropagateCompletion = true});
        //Load the data in to the first transform block to start off the process.
        foreach (var uri in uris)
        {
            await downloadData.SendAsync(uri).ConfigureAwait(false);
        }
        downloadData.Complete(); //Signal you are done adding data.
        //Wait for the last object to be added to the list.
        await collectData.Completion.ConfigureAwait(false);
        return result;
    }
