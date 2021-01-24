    byte[] reservedData = binaryReader.ReadBytes(96);
    byte[] signature = binaryReader.ReadBytes(2);
    byte[] tsPropertyCount = binaryReader.ReadBytes(2);
    
    string signatureValue = Encoding.Unicode.GetString(signature);
    ushort tsPropertyCountValue = BitConverter.ToUInt16(tsPropertyCount, 0);
