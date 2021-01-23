    public async Task DoSomething()
    {
        for (int i = 0; i < doc.GetElementsByTagName("ItemID").Count; i++)
        {
            Task.Run(() => PerformHttpRequestMethod());
            if(i%2==0){
                await Task.Delay(TimeSpan.FromMinutes(2));
            }
        }
    }
