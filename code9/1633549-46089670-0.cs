    using(var stream = new FileStream(sFile, FileMode.Open, FileAccess.Read)
    using(var reader = new StreamReader(stream, Encoding.UTF8))
    {
        long position = GetFirstNewRecordOfFile(sFile);
        stream.Seek(position, SeekOrigin.Begin);
        while(!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            // Process line 
        }
        SaveFirstNewRecordOfFile(sFile, stream.Position);
    }
