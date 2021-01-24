    public async Task FireLotsOfQueries()
    {
        var counter = 0;
        var taskList = Enumerable.Range(0, 10000)
            .Select(_=> Task.Run(async () =>
            {
                ++counter;
                await Task.Delay(1000);
            }));
        await Task.WhenAll(taskList);
        Assert.Equal(10000, counter);
    }
