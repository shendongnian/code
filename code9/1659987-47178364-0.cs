    static async Task MyMethodAsync(Action<double> progress = null)
    {
        int done = 0;
        while (done<100)
        {
            if (progress != null)
                progress.Invoke(done);
            done++;
        }
    }
