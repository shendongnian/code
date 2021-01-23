        public void callback(IAsyncResult ar)
        {
            this.clientConnection.EndConnect(ar);
        }
        var result = clientConnection.BeginConnect(ip, port, new AsyncCallback(callback), clientConnection);
