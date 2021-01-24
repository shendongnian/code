	var zipFiles = _directory.ListFilesAndDirectories()
		.OfType<CloudFile>()
		.Where(x => x.Name.ToLower().Contains(".zip"))
		.ToList();
	foreach (var zipFile in zipFiles)
	{
		using (var zipArchive = new ZipArchive(zipFile.OpenRead()))
		{
			foreach (var entry in zipArchive.Entries)
			{
				if (entry.Length > 0)
				{
					CloudFile extractedFile = _dirIn.GetFileReference(entry.Name);
					extractedFile.Create(entry.Length);
					using (var entryStream = entry.Open())
					{
						extractedFile.WriteRange(entryStream, 0);
					}
				}
			}
		}		
	}
