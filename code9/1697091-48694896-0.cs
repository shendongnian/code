    void Zip(IEnumerable<string> files, Stream inputStream)
	{
		using (var zip = new System.IO.Compression.ZipArchive(inputStream, System.IO.Compression.ZipArchiveMode.Create))
		{
			foreach (var file in files.Select(f => new FileInfo(f)))
			{
				var entry = zip.CreateEntry(file.Name, System.IO.Compression.CompressionLevel.Fastest);
				using (var s = entry.Open())
				{
					using (var f = File.Open(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						f.CopyTo(s);
					}
				}
			}
		}
	}
