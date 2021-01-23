    Byte[] b = GetByteArray();
    using(BinaryReader r = new BinaryReader(new MemoryStream(b)))
    {
        r.ReadInt32();
        r.ReadDouble();
        r.Read...();
    }
