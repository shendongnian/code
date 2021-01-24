    internal class MockIndex<T, T1> : Dictionary<T, T1>, IIndex<T, T1>
    {
    }
    IIndex<FileTransportTypeEnum, IMessageHandler> index = new MockIndex<MessageTypeEnum, IMessageHandler>
    {
        {MessageTypeEnum.A, new TypeAMessageHandler()},
        {MessageTypeEnum.B, new TypeBMessageHandler()}
    };
    _target = new MessageHandlerFactory(index);
