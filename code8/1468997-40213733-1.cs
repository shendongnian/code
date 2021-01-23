	static void Main(string[] args)
	{
		using (var inputStream = new MemoryStream())
		{
			BinaryReader reader = new MyBinaryReader(inputStream);
			long myValue = reader.ReadInt64();
		}
	}
	
