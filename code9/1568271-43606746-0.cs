        byte [] buffer = new byte[1024];
        using (var memoryStream = new MemoryStream(buffer))
        {
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                binaryWriter.Write(1.2F); // float
                binaryWriter.Write(1.9D); // double
                binaryWriter.Write(1); // integer
                binaryWriter.Write("str"); // string
            }
        }
        // buffer is filled with your data now. 
