    SocketReader.ReadFromSocket(socket, 2, (headerData) =>
    {
        if(headerData.Count == 0)
        {
            // nothing/closed
            return;
        }
        // Get the protocol key:
        int length = BitConverter.ToInt16(headerData.Array, headerData.Offset);
        SocketReader.ReadFromSocket(socket, length, (dataBufferSegment) =>
        {
            if(dataBufferSegment.Count == 0)
            {
                // nothing/closed
                return;
            }
            Process(dataBufferSegment);
        }
    });
