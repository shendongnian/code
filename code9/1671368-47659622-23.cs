    byte[] nameLength = binaryReader.ReadBytes(2);
    byte[] valueLength = binaryReader.ReadBytes(2);
    byte[] type = binaryReader.ReadBytes(2);
    
    ushort nameLengthValue = BitConverter.ToUInt16(nameLength, 0);
    ushort valueLengthValue = BitConverter.ToUInt16(valueLength, 0);
    ushort typeValue = BitConverter.ToUInt16(type, 0);
    
    byte[] propName = binaryReader.ReadBytes(nameLengthValue);
    byte[] propValue = binaryReader.ReadBytes(valueLengthValue);
    
    string propNameValue = Encoding.Unicode.GetString(propName);
    byte[] propValueValue = GetPropValueValue(propValue);
