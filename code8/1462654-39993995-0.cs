    using (MemoryStream stream = new MemoryStream(_buffer))
    using (BeBinaryReader BeReader = new BeBinaryReader(stream))
    {
        double YourDouble = BeReader.ReadDouble();
    }
