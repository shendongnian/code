    public async Task ParentMethodAsync() {
        DoSomeSyncStuff();
        await DoBigStuffAsync();
        DoSomeSyncStuffAfterAsyncBigStuff();
    }
    public async Task DoBigStuffAsync() {
        await Task.Run(() => {
            DoBigSyncStuff();
        });
    }
