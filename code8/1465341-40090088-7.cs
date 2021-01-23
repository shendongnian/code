    public IMessage ProcessMessage(IMessage message)
    {
        var handler = _messageHandlerFactory.GetHandler(message.Code);
        return handler.Transform(message);
    }
