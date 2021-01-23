	static void Main(string[] args)
	{
		using (var inputStream = new MemoryStream()) // Just a dummy stream, for the sake of the example.
		{
			BinaryReader reader = new MyBinaryReader(inputStream);
			long myValue = reader.ReadInt64();
		}
	}
	
