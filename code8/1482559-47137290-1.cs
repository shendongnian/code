    private static char ReadUTF8Char(BinaryReader reader)
    {
    	var s = reader.BaseStream;
        if (s.Position >= s.Length)
            throw new Exception("Error: Read beyond EOF");
        int numRead = Math.Min(4, (int)(s.Length - s.Position));
        byte[] bytes = reader.ReadBytes(numRead);
        char[] chars = Encoding.UTF8.GetChars(bytes);
        if (chars.Length == 0)
            throw new Exception("Error: Invalid UTF8 char");
        int charLen = Encoding.UTF8.GetByteCount(new char[] { chars[0] });
        s.Position += (charLen - numRead);
        return chars[0];
    }
