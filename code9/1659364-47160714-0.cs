    public BuildPipeline() {
        var waitTime = TimeSpan.FromSeconds(1);
        var retryPolicy = Policy.Handle<IOException>()
                                .WaitAndRetryAsync(3, i => waitTime);
        var fileIOBlock = new ActionBlock<string>(async fileName => await retryPolicy.ExecuteAsync(async () => await FileIOAsync(fileName)));
    }
