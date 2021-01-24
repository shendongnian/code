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
					using (var ms = new MemoryStream())
					{
						using (var entryStream = entry.Open())
						{
							entryStream.CopyTo(ms);
						}
						CloudFile extractedFile = _directory.GetFileReference(entry.Name);
						ms.Position = 0;
						extractedFile.UploadFromStream(ms);
					}
				}
			}
		}
	}
