    public async Task TimoutReversal() {
        var timeout = TimeSpan.FromSeconds(10);
        try {
            //assumes HttpClient 
            await Client.GetAsync(firstEndpoint, new CancellationTokenSource(timeout).Token);
        } catch (OperationCanceledException ex) {
            await Client.DeleteAsync(secondEndpoint);
        }
    }
    //or
    public async Task TimoutReversal() {
        var timeout = TimeSpan.FromSeconds(10);
        var firstTask = Client.GetAsync(firstEndpoint);
        if (await Task.WhenAny(firstTask, Task.Delay(timeout)) == firstTask) {
            //success
        }else {
            //failure
            await Client.DeleteAsync(secondEndpoint);
        }
    }
