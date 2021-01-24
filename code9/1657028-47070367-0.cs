     public static ulong getAsciiLiteral(string x)
    {
        int len = x.Length;
        string[] strArray = new string[32];
        byte[] finalByte = new byte[32];
        int i = 0;
        int i2 = 0;
        int i3 = 0;
        int offset = 0;
        var hexFinalString = "0x";
        var bytes = Encoding.ASCII.GetBytes(x);
        if(len >= 5)
        {
            while (true)
            {
                if (4 + i3 == len)
                {
                    offset = i3;
                    break;
                }
                else
                {
                    i3++;
                }
            }
           
        }
     
        foreach (byte b in bytes)
        {
            strArray[i] = b.ToString("X2");
            i++;
        }
        i = 0;
        i3 = 0;
        while (i3 < len - 1)
        {
          
          
            hexFinalString += strArray[offset];
            offset++;
            i3++;
        }
     
    
        var ret = Convert.ToUInt64(hexFinalString, 16);
        return ret;
            
    }
