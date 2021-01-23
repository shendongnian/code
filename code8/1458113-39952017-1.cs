	public static byte[] StringToByteArray(string hex)
	{
		int startIndex = 0;
		if (hex.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase))
			startIndex = 2;
		return Enumerable.Range(startIndex, hex.Length - startIndex)
						 .Where(x => x % 2 == 0)
						 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
						 .ToArray();
	}
	public static string ByteArrayToString(byte[] arr)
	{
		return "0x" + BitConverter.ToString(arr).Replace("-", String.Empty);
	}
