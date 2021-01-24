     public void Connect()
     {
            _channel = new DefaultWampChannelFactory().ConnectToRealm(_realm)
                .WebSocketTransport(prtcl => CreateWebSocket(prtcl, _url))
                .JsonSerialization()
                .Build();
            //.CreateJsonChannel(_url, _realm);
            //_channel.RealmProxy.
            _channel.RealmProxy.Monitor.ConnectionBroken += (sender, args) =>
            {
                _logger.WriteError(string.Format("ConnectionError -> From connection error event WssUrl : {0} , Realm : {1}", _url, _realm), new ArgumentException(args.Details != null ? args.Details.Message : "NO Details" ));
            };
             _channel.RealmProxy.Monitor.ConnectionError += (sender, args) =>
             {
                 _logger.WriteError(string.Format("ConnectionError -> From connection error event WssUrl : {0} , Realm : {1}",_url,_realm), args.Exception);
             };
             _channel.RealmProxy.Monitor.ConnectionEstablished += (sender, args) =>
             {
                 string info = string.Format("from ConnectionEstablished event -> WssUrl : {0} , Realm : {1}", _url, _realm);
                 OnConnected(info);
             };
            _reconnector = new WampChannelReconnector(_channel, ConnectInternal);
            _reconnector.Start();
        }
        private static WebSocket CreateWebSocket(string subprotocolName, string serverAddress)
        {         
            WebSocket result = new WebSocket(serverAddress,
                subprotocolName, null, null, string.Empty, string.Empty, WebSocketVersion.None,null,SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12, 4096);
            result.AutoSendPingInterval = 10;
        
            return result;
     }
 
