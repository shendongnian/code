    async void TopLevelMethod()
    {
        while (!Console.Read().Equals('q'))
        {
           await DoWork();
        }
    }
    async Task DoWork()
    {
        await Task.Delay(100);
    }
