    byte[] foo;
    Object obj = BitmapObject;
    BinaryFormatter bf = new BinaryFormatter();
    using (var ms = new MemoryStream())
    {
        bf.Serialize(ms, obj);
        foo = ms.ToArray();
    }
    
