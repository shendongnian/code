    var proxy = await _proxyProviderFactory.GetProxyProvider().GetProxyAsync().ConfigureAwait(false);
    if (!string.IsNullOrEmpty(proxy))
    {
        TcpClient TcpHandler(string address, int port)
        {
            var split = proxy.Split(':');
            var socksProxy = new Socks5ProxyClient(split[0], int.Parse(split[1]), split[2], split[3]);
            var tcpClient = socksProxy.CreateConnection(address, port);
            return tcpClient;
        }
    
        _client = new TelegramClient(_telegramApiId, _telegramApiHash, _sessionStore,handler:TcpHandler);
