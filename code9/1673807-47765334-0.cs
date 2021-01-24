    protected static byte[] Enc3DesPerChar(String toEncrypt)
    {
        string toAsciiString = ByteArrayToString(Encoding.ASCII.GetBytes(toEncrypt));
        string toRoll = toAsciiString.PadRight(16,'0');
        int NumberChars = toRoll.Length;
        byte[] bytes = new byte[NumberChars / 2];
        for (int i = 0; i < NumberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(toRoll.Substring(i, 2), 16);
        }
        return bytes;
    }
