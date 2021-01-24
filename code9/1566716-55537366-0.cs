    private async Task PersistConnectionAsync()
    {
        var connected = _mqttClient.IsConnected;
        while (_tryReconnectMQTT)
        {
            if (!connected)
            {
                try
                {
                    _mqttClient.Connect(_clientId);
                }
                catch
                {
                    Debug.WriteLine("failed reconnect");
                }
            }
            await Task.Delay(1000);
            connected = _mqttClient.IsConnected;
        }
    }
