    using(var fileStream = new FileStream(@"D:\temp.bin", FileMode.Create, FileAccess.Write, FileShare.None))
    {
        using(var bw = new BinaryWriter(fileStream))
        {
            foreach(Dictionary<string, object[]> row in rows)
            {
                byte[] bytes = ObjectToByteArray(row);
                bw.Write(bytes.Length);
                bw.Write(bytes);
            }
        }
    }
    using(BinaryReader reader = new BinaryReader(File.Open(@"D:\temp.bin", FileMode.Open)))
    {
        int length = (int)reader.BaseStream.Length;
        while(reader.BaseStream.Position != length)
        {
            int bytesToRead = reader.ReadInt32();
            byte[] v = reader.ReadBytes(bytesToRead);
            Dictionary<string, object[]> row = FromByteArray(v);
        }
    }                
