    Message Receive()
    {
        int messageLength = stream.Read(bytes, 0, bytes.Length);
        byte[] data = new byte[messageLength];
        Array.Copy(bytes, data, messageLength);
    
        Message message = Serializer.Deserialize(data); // DESERIALIZE
        return message;
    }
