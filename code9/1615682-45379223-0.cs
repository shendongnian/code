    public delegate Task MyAsyncEventHandler(object sender, MyEventArgs e);
    public event MyAsyncEventHandler MyEvent;
    private async Task InvokeMyEvent()
    {
        var args = new MyEventArgs();
        // Keep the UI responsive until this returns
        var myEvent = MyEvent;
        if (myEvent != null)
            await Task.WhenAll(Array.ConvertAll(
              myEvent.GetInvocationList(),
              e => ((MyAsyncEventHandler)e).Invoke(this, args)));
        // Then show the result
        MessageBox.Show(args.Result);
    }
