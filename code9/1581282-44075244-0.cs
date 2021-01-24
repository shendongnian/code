	internal async Task<string> UsingStream(StorageFile sampleFile)
	{
		IRandomAccessStream stream = await sampleFile.OpenAsync(FileAccessMode.Read);
		ulong size = stream.Size;
		string text = string.Empty;
		using (var inputStream = stream.GetInputStreamAt(0))
		{
			using (var dataReader = new DataReader(inputStream))
			{
				uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
				text = dataReader.ReadString(numBytesLoaded);
			}
		}
		return text;
	}
