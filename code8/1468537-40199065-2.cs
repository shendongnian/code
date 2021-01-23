    private async void button1_Click(object sender, EventArgs e)
    {
        // Your original example didn't show how you used this value,
        // so I don't have anything in this example that uses it. But you
        // would probably want to pass it to the "DoSomething..." methods
        // so that those methods can then pass the token to whatever async
        // operation they are actually doing. See additional comment below.
        var token = Task.Factory.CancellationToken;
    
        var tasks = new[]
        {
            DoSomething1(),
            DoSomething2(),
            DoSomething3()
        };
        await Task.WhenAll(tasks);
    
        int x=0;
    }
    
    public async Task void DoSomething1()
    {
        this.label3.Text = "DoSomething1 -- " + System.Threading.Thread.CurrentThread.ManagedThreadId;
        // replace with `Task.Run()` or whatever already-asynchronous
        // operation you need/want. Likewise in the other methods.
        // Don't forget to pass the CancellationToken to these methods,
        // and then on to whatever tasks you actually are running.
        await Task.Delay(1000);
    }
    
    public async Task DoSomething2()
    {
        this.label4.Text = "DoSomething2 -- " + System.Threading.Thread.CurrentThread.ManagedThreadId;
        await Task.Delay(1000);
    }
    
    public async Task DoSomething3()
    {
        this.label5.Text = "DoSomething3 -- " + System.Threading.Thread.CurrentThread.ManagedThreadId;
        await Task.Delay(1000);
    }
