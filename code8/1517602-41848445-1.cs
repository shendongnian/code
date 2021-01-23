    FileInfo meFile = //.. get the file
    byte[] extBytes = Encoding.ASCII.GetBytes(meFile.Extension);
    using(FileStream stream = meFile.OpenRead())
    {
        networkStream.Write(extBytes, 0, extBytes.Length);
        networkStream.Write(BitConverter.GetBytes(stream.BaseStream.Length));
        byte @byte = 0x00;
        while ( stream.Position < stream.BaseStream.Length )
        {
            networkStream.WriteByte((byte)stream.ReadByte());
        }
    }
