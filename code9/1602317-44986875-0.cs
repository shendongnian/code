    short command = 0;
    short payloadSize = 0;
    byte[] payload = null;
    
    bool packetHeaderRead = false;
    
    while (connected)
    {
        if (!packetHeaderRead)
        {
            if (dataReader.UnconsumedBufferLength < PacketHeaderSize)
            {
                int headerBytesLeft = PacketHeaderSize - (int)dataReader.UnconsumedBufferLength;
    
                if (headerBytesLeft > 0)
                {
                    await dataReader.LoadAsync((uint)headerBytesLeft);
                    continue;
                }
            }
            else
            {
                command = dataReader.ReadInt16();
                payloadSize = dataReader.ReadInt16();
                packetHeaderRead = true;
                continue;
            }
        }
        else
        {
            int payloadBytesLeft = payloadSize - (int)dataReader.UnconsumedBufferLength;
    
            if (payloadBytesLeft > 0)
            {
                await dataReader.LoadAsync((uint)payloadBytesLeft);
            }
    
            if (payloadSize == 0)
            {
                Packet packet = new Packet(command, payloadSize, payload);
                ParsePacket(packet);
    
                packetHeaderRead = false;
            }
            else if (dataReader.UnconsumedBufferLength >= payloadSize)
            {
                payload = new byte[payloadSize];
                dataReader.ReadBytes(payload);
    
                Packet packet = new Packet(command, payloadSize, payload);
                ParsePacket(packet);
    
                packetHeaderRead = false;
            }
        }
    }
