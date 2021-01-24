    // async void is a recommended way to use asynchronous event handlers
    private async void btnReadAll_Click(object sebder, EventArgs e)
    {
        var data = new byte[2];
    
        // cancel source after 10 seconds
        var cts = new CancellationTokenSource(10000);
        // Read all information
        // [omit communication exchange via COM port]
        // async operation with BaseStream
        var result = await SerialPort.BaseStream.ReadAsync(data, 0, 2, cts.Token);
    
        /*
         * if you can't use the BaseStream methods, simply call this method here
         * cts.Token.ThrowIfCancellationRequested();
        */
        
        // this code would run only if everything is ok
    
        // check result here in your own way
        var boolFlag = result != null;
    
        ReadAllComplete?.Invoke(boolFlag);
    }
