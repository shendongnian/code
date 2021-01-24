    Dictionary<byte, Func<byte[], IMessage>> converters = 
                                            new Dictionary<byte, Func<byte[], IMessage>>();
    public void CreateConverter<T>(byte Id) where T : IMessage
    {
        converters.Add(Id, (byte[] Data) => ZeroFormatterSerializer.Deserialize<T>(Data.Skip(1)));
    }
    public IMessage Deserialize(byte[] Data)
    {
        return converters[data[0]](Data);
    }
 
    //Somewhere on your initialization code...
    CreateConverter<0, MessageOne>();
    CreateConverter<1, MessageTwo>();
    //...
    //Now you can simply do
    IMessage msg = Deserialize(Data);
