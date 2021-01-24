    public static byte[] GetBytes(MsgData message)
    {
        using (var stream = new MemoryStream())
        {
            new BinaryFormatter().Serialize(stream, message);
            return stream.ToArray();
        }
    }
    
    public static MsgData GetMessage(byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes))
        {
            return (MsgData)new BinaryFormatter().Deserialize(stream);
        }
    }
