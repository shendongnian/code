    public static byte[] HexStringToByteArray(string Hex)
    {  
        if(1 == (Hex.length&1))  throw new Exception("Hex string cannot have an odd number of characters");
        return Enumerable.Range(0, hex.Length <<1 ) 
            .Select(x => Convert.ToByte(hex.Substring(x << 1, 2), 16)) 
            .ToArray();
    }
