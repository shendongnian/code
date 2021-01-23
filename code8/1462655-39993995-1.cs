    using (MemoryStream stream = new MemoryStream())
    using (BeBinaryReader BeReader = new BeBinaryReader(stream))
    {
        stream.Position = 3;
        if(BeReader.ReadByte() == paramCount)
        for (int i = 0; i < paramCount; i++)
        {
           double Value = BeReader.ReadDouble();
           fmacsParams[i].NumericalValue = Value;
        }
     }
