    public static async Task<int> DummyWorkAsync()
    {
        // Do some I/O first.
        await Task.Delay(1000).ConfigureAwait(false);
        // Tons of work to do in here!
        // no problem, we are not on UI thread anyway
        for (int i = 0; i != 10000000; ++i)
            ;
        // Possibly some more I/O here.
        await Task.Delay(1000).ConfigureAwait(false);
        // More work.
        for (int i = 0; i != 10000000; ++i)
           ;
        return 0;
    }
