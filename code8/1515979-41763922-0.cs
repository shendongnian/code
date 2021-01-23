	public byte[] Compress(string input)
	{
		var bytes = Encoding.UTF8.GetBytes(input);
	
		var msi = new MemoryStream(bytes);
		var mso = new MemoryStream();
		using (var gz = new GZipStream(mso, CompressionMode.Compress))
		{
			msi.CopyTo(gz);
		}
	
		return mso.ToArray();
	}
	
