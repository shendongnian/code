    ..
    MS.Seek(0, SeekOrigin.Begin);
    byte[] bytes = MS.ToArray();
    Array.Reverse(bytes);
    int z = 0;
    for (int i = 0; i < bytes.Length; i+=4)
    {
        int v = bytes[i] +  bytes[i+1] +  bytes[i+2] +  bytes[i+3];
        if (v == 0) { z = i; break; }
    }
    MS.SetLength(bytes.Length - z);
    ..
