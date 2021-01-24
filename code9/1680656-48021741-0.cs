    private CancellationToken _ct;
    
    void Handler1()
    {
        var ts = new CancellationTokenSource();
        C_ct = ts.Token;
        Device.BeginInvokeOnMainThread(() => Show(ct).ContinueWith((arg) => { }));
    }
    void Handler2()
    {
        if (_ct != null)
        {
            _ct.Cancel(); // <---- Cancel here
        }
    }
    public async Task Show(CancellationToken ct)
    {
        while (true)
        {
            await Task.Delay(500);
            Debug.WriteLine("test1");
            if (ct.IsCancellationRequested)
            {
                // another thread decided to cancel
                Console.WriteLine("Show canceled");
                break;
            }
        }
    }
