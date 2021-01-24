    void HandleMessage(byte[] messageBA)
    {
        // This block is all from the Bond examples
        var input = new InputBuffer(messageBA);
        var reader = new CompactBinaryReader<InputBuffer>(input);
        MainExample message = Deserialize<BondEvent>.From(reader);
    
        DerivedExample de = message.mainProperty.Deserialize<DerivedExample>();
    }
