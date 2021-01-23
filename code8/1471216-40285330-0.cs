        using (FileStream streamToRead = File.OpenRead(fileName))
        using (BinaryReader reader = new BinaryReader(streamToRead))
        using (FileStream streamToWrite = File.Create(@"D:\temp\encrypted.jpg"))
        using (BinaryWriter writer = new BinaryWriter(streamToWrite))
        {
           for (int i = 0; i < streamToRead.Length; i++)
           {
              byte b = reader.ReadByte();
              writer.Write((byte)(b + ENCRYPE_KEY));
           }
        }
