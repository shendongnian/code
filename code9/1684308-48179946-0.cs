    private void Broast(Action<IDataExchangeServiceCallBack> callback)
    {
        foreach (var channel in _callbackChannelList.ToArray())
        {
            try
            {
                //invoke
                callback(channel.Value);
            }
            catch (Exception ex)
            {
                _callbackChannelList.TryRemove(channel.Key, out _);
            }
        }
    }
