    byte[] StringToByteArray(String hex)
    {
        int NumberChars = hex.Length;
        byte[] bytes = new byte[NumberChars / 2];
        for (int i = 0; i < NumberChars; i += 2)
        {
            var pair=hex.Substring(i, 2);
            if (!(byte.TryParse(pair, NumberStyles.HexNumber, CultureInfo.InvariantCulture, 
                                out bytes[i / 2])))
			{
			    throw new FormatException($"Invalid pair {pair} at {i}");
			}
            return bytes;
        }
    }
