    byte[] foo;
    Object obj = YourBitmap;
    BinaryFormatter bf = new BinaryFormatter();
    using (var ms = new MemoryStream())
    {
        bf.Serialize(ms, obj);
        foo = ms.ToArray();
    }
    
