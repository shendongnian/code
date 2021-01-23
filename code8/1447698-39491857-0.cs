    string s = "AA";
    byte byteValue = 0; 
    try
    {
        byteValue = byte.Parse(s, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);
    }
    catch (Exception e)
    {
         Console.WriteLine(e);
    }
       
    Console.WriteLine("String value: 0x{0}, byte value: {1}", s, byteValue);
