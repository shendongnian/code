    byte messageType = (1 << 3); // assume that 0000 1000 would be XML
    byte[] message = Encoding.ASCII.GetBytes(xml);
    byte[] length = BitConverter.GetBytes(message.Length);
    byte[] buffer = new byte[sizeof(int) + message.Length + 1];
    buffer[0] = messageType;
    for(int i = 0; i < sizeof(int); i++)
    {
        buffer[i + 1] = length[i];
    }
    for(int i = 0; i < message.Length; i++)
    {
        buffer[i + 1 + sizeof(int)] = message[i];
    }
    netStream.Write(buffer);
