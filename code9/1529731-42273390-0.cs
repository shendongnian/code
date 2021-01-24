    public async Task DoWorkAsync()
    {
        Action<int> onNext = Console.WriteLine;
        await Task.Delay(1000);
        onNext(1);
        throw new Exception("exception in DoWork logic"); // ... or don't
    }
