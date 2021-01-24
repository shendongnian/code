    var n = 5;
    byte customByte = 0xFF;
    var bytes = File.ReadAllBytes(path);
    for (var i = 0; i < bytes.Length; i++)
    {
        if (i%n == 0)
        {
            bytes[i] = customByte;
        }
    }
    File.WriteAllBytes(path, bytes);
