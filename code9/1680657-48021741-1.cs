    private CancellationTokenSource _cts;
    
    void Handler1()
    {
        _cts = new CancellationTokenSource();
        Device.BeginInvokeOnMainThread(() => Show(_cts.Token).ContinueWith((arg) => { }));
    }
    void Handler2()
    {
        if (_cts != null)
        {
            _cts.Cancel(); // <---- Cancel here
        }
    }
    public async Task Show(CancellationToken ct)
    {
        while (true)
        {
            await Task.Delay(500, ct); // <-- Thanks to @Evk's suggestion
            Debug.WriteLine("test1");
            if (ct.IsCancellationRequested)
            {
                // another thread decided to cancel
                Console.WriteLine("Show canceled");
                break;
            }
        }
    }
