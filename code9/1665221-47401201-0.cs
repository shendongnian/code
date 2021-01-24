    public static MessageClass NewMessageClass(byte[] packetBody)
    {
        var messageData = new byte[Length];
        Array.Copy(packetBody, 0, messageData, 0, Length);
        return new MessageClass(messageData);
    }
