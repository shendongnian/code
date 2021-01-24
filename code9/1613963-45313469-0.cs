    ..
    MS.Seek(0, SeekOrigin.Begin);
    byte[] bytes = MS.ToArray();
    Array.Reverse(bytes);
    int z = 0;
    for (int i = 0; i < bytes.Length; i+=4)
    {
        int v = bytes[0] +  bytes[1] +  bytes[2] +  bytes[3];
        if (v == 0) { z = i; break; }
    }
    MS.SetLength(bytes.Length - z);
    ..
