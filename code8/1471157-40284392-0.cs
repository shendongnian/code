    var newBytes = new List<byte>();
    ...
    for (int i = 0; i < stream.Length; i++)
    {
        byte b = reader.ReadByte();
        newBytes.Add(b + 5);
    }
    ...
    File.WriteAllBytes(filePath, newBytes.ToArray());
