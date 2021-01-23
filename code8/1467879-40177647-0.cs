		private FileResult CreateZip(IEnumerable<FileContentResult> files)
		{
			byte[] retVal = null;
			if (files.Any())
			{
				using (MemoryStream zipStream = new MemoryStream())
				{
					using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
					{
						foreach (var f in files)
						{
							var entry = archive.CreateEntry(f.FileDownloadName, CompressionLevel.Fastest);
							using (BinaryWriter writer = new BinaryWriter(entry.Open()))
							{									
								writer.Write(f.FileContents, 0, f.FileContents.Length);
								writer.Close();
							}
						}
						zipStream.Position = 0;
					}
					retVal = zipStream.ToArray();
				}
			}
			
			return File(retVal, MediaTypeNames.Application.Zip, "horta.zip");
		}
