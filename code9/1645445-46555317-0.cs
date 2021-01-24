    public async void PersistTask()
    {
        // no need to assign the task if you are just going to await for it.
        await Task.Run(() =>
        {
            Thread.Sleep(3000);
            Console.WriteLine("First");
            return Task.FromResult(0);
        });
    }
