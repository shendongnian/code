    SocketReader.ReadFromSocket(socket, 2, (headerData) =>
    {
        if(headerData.Count == 0)
        {
            // nothing/closed
            return;
        }
        // Read the length of the data.
        int length = BitConverter.ToInt16(headerData.Array, headerData.Offset);
        SocketReader.ReadFromSocket(socket, length, (dataBufferSegment) =>
        {
            if(dataBufferSegment.Count == 0)
            {
                // nothing/closed
                return;
            }
            Process(dataBufferSegment);
            // extra: if you need a binaryreader..
            using(var stream = new MemoryStream(dataBufferSegment.Array, dataBufferSegment.Offset, dataBufferSegment.Count))
            using(var reader = new BinaryReader(stream))
            {
                var whatever = reader.ReadInt32();
            }
        }
    });
