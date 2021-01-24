	public static void ConvertFileEncoding(string srcFile, Encoding srcEncoding, string destFile, Encoding destEncoding)
	{
		using (var reader = new StreamReader(srcFile, srcEncoding))
		using (var writer = new StreamWriter(destFile, false, destEncoding))
		{
			char[] buf = new char[4096];
			while (true)
            {
				int count = reader.Read(buf, 0, buf.Length);
				if (count == 0)
					break;
				
				writer.Write(buf, 0, count);
			}
		}
	}
