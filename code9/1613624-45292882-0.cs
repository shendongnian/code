    if (_client.DefaultRequestHeaders.Contains("ConnectionClose"))
    {
                _client.DefaultRequestHeaders.Remove("ConnectionClose");
    }
    _client.DefaultRequestHeaders.ConnectionClose = _closingConnections
