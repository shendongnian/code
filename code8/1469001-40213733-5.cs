	static void Main(string[] args)
	{
		// Just a dummy stream, for the sake of the example.
		using (var inputStream = new MemoryStream())
		{
			BinaryReader reader = new MyBinaryReader(inputStream);
			long myValue = reader.ReadInt64();
		}
	}
	
