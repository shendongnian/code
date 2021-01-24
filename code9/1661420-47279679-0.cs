    public static string ByteArrayToHexaDecimalString(byte[] bytes)
    {
         StringBuilder stringBuilder = new StringBuilder(bytes.Length * 2);
         foreach (byte b in bytes) { stringBuilder.AppendFormat("{0:x2}", b); }
         return stringBuilder.ToString();
    }
    
    public static byte[] HexaDecimalStringToByteArray(String hexaDecimalString)
    {
         int NumberChars = hexaDecimalString.Length;
         byte[] bytes = new byte[NumberChars / 2];
         for (int i = 0; i < NumberChars; i += 2)
         { 
             bytes[i / 2] = Convert.ToByte(hexaDecimalString.Substring(i, 2), 16); 
         }
         return bytes;
    }
