	using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
	{
		int size = 4096;
		Encoding targetEncoding = Encoding.GetEncoding(1252);
		byte[] byteData = new byte[size];
		using (FileStream outputStream = new FileStream(outputFilepath, FileMode.Create))
		{
			int byteCounter = 0;
			do
			{
				byteCounter = fileStream.Read(byteData, 0, size);
				// Convert the 4k buffer
				byteData = Encoding.Convert(srcEncoding, targetEncoding, byteData);
				
				if (byteCounter > 0)
				{
					outputStream.Write(byteData, 0, byteCounter);
				}
			}
			while (byteCounter > 0);
			inputStream.Close();
		}
	}
