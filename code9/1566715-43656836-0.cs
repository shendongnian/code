     private async Task TryReconnectAsync(CancellationToken cancellationToken)
        {
            var connected = _client.IsConnected;
            while (!connected && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    _client.Connect(_clientId);
                }
                catch
                {
                    _logger.Log(LogLevel.Warn, "No connection to...{0}",_serverIp);
                }
                connected = _client.IsConnected;
                await Task.Delay(10000, cancellationToken);
            }
        }
