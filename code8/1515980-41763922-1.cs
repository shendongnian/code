	public byte[] Compress(string input)
	{
		var bytes = Encoding.UTF8.GetBytes(input);
		using (var msi = new MemoryStream(bytes))
		using (var mso = new MemoryStream())
		{
			using (var gz = new GZipStream(mso, CompressionMode.Compress))
			{
				msi.CopyTo(gz);
			}
			return mso.ToArray();
		}
	}
