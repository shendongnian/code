    public async Task ParentMethodAsync() {
        DoSomeSyncStuff();
        // original context/thread
        await DoBigStuffAsync();
        // same context/thread as original
        DoSomeSyncStuffAfterAsyncBigStuff();
    }
    public async Task DoBigStuffAsync() {
        // here you are on the original context/thread
        await Task.Run(() => {
            // this will run on a background thread if possible
            DoBigSyncStuff();
        }).ConfigureAwait(false);
        // here the context/thread will not be the same as original one
    }
