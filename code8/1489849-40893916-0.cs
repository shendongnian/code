    client.InnerChannel.Closed += OnChannelClosed;
    client.InnerChannel.Opening += OnChannelOpening;
    client.InnerChannel.Opened += OnChannelOpened;
    client.InnerChannel.Closing += OnChannelClosing;
    client.InnerChannel.Faulted += OnChannelFaulted;
    client.InnerChannel.UnknownMessageReceived += OnChannelUnknownMessageReceived;
