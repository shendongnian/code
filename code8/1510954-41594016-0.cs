    Int32 original = 0x12345678;
    byte[] bytes = BitConverter.GetBytes(original);
    foreach (var b in bytes)
        Console.WriteLine(b.ToString("02X"); // write in two digit hex format
    // will write lines with 78 56 34 12
    Int16[] Values = new Int16[]
    {
        BitConverter.ToInt16(bytes),     // LSB
        BitConverter.ToInt16(bytes, 2),  // MSB
    };
    Int32 result = (Int32)values[0] + (Int32)values[1] << 0x10000;
    Debug.Assert(original == result);
