    public struct S
    {
        public double value;
        
        public S(double d)
        {
            value = d;
        }
    }
    public static void Main(string[] args)
    {           
        double d1 = 0;
        double d2 = d1 / -1;
                       
        Console.WriteLine("using double");
        Console.WriteLine("{0} {1}", d1, d1.GetHashCode());
        Console.WriteLine(GetComponentParts(d1));
        Console.WriteLine("{0} {1}", d2, d2.GetHashCode());
        Console.WriteLine(GetComponentParts(d2));
        Console.WriteLine("Equals: {0}, Hashcode:{1}, {2}", d1.Equals(d2), d1.GetHashCode(), d2.GetHashCode());
            
        Console.WriteLine();
        Console.WriteLine("using a custom struct");
            
        var s1 = new S(d1);
        var s2 = new S(d2);
        Console.WriteLine(s1.Equals(s2));
        Console.WriteLine(new S(d1).GetHashCode());
        Console.WriteLine(new S(d2).GetHashCode());            
    }
    // from: https://msdn.microsoft.com/en-us/library/system.double.epsilon(v=vs.110).aspx
    private static string GetComponentParts(double value)
    {
        string result = String.Format("{0:R}: ", value);
        int indent = result.Length;
        // Convert the double to an 8-byte array.
        byte[] bytes = BitConverter.GetBytes(value);
        // Get the sign bit (byte 7, bit 7).
        result += String.Format("Sign: {0}\n", 
                              (bytes[7] & 0x80) == 0x80 ? "1 (-)" : "0 (+)");
        // Get the exponent (byte 6 bits 4-7 to byte 7, bits 0-6)
        int exponent = (bytes[7] & 0x07F) << 4;
        exponent = exponent | ((bytes[6] & 0xF0) >> 4);  
        int adjustment = exponent != 0 ? 1023 : 1022;
        result += String.Format("{0}Exponent: 0x{1:X4} ({1})\n", new String(' ', indent), exponent - adjustment);
        // Get the significand (bits 0-51)
        long significand = ((bytes[6] & 0x0F) << 48); 
        significand = significand | ((long) bytes[5] << 40);
        significand = significand | ((long) bytes[4] << 32);
        significand = significand | ((long) bytes[3] << 24);
        significand = significand | ((long) bytes[2] << 16);
        significand = significand | ((long) bytes[1] << 8);
        significand = significand | bytes[0];    
        result += String.Format("{0}Mantissa: 0x{1:X13}\n", new String(' ', indent), significand);    
        return result;   
    }
     
