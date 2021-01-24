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
