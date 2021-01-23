    byte[] StringToByteArray(String hex)
    {
        int NumberChars = hex.Length;
        byte[] bytes = new byte[NumberChars / 2];
        for (int i = 0; i < NumberChars; i += 2)
        {
            var pair=hex.Substring(i, 2);
            try
            {
                bytes[i / 2] = Convert.ToByte(pair, 16);
            }
            catch (FormatException exc)
            {
                throw new FormatException($"Invalid pair {pair} at {i}", exc);
            }
            return bytes;
    }
