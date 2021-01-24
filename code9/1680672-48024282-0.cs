    while (!token.IsCancellationRequested) {
        if (_server.Pending()) {
            var client = await _server.AcceptTcpClientAsync();
            // insert code for handling new connection
        }
        Thread.Sleep(500);
    }
