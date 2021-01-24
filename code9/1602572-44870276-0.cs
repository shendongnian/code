    void Do()
    {
        // Some code
        Task.Factory.StartNew(() =>
        {
            SaveResult1();
            SaveResult2();
        })
        .ContinueWith(t =>
        {
            // Other code
        });
    }
