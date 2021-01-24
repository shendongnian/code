	public static class SerializationExtensions
	{
		public static byte[] ToCompressedXmlZipArchive<T>(T root, string entryName)
		{
			using (var zipStream = new MemoryStream())
			{
				using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
				{
					var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
					using (var zippedFileStream = entry.Open())
					{
						new XmlSerializer(typeof(T)).Serialize(zippedFileStream, root); // Possibly use root.GetType() instead of typeof(T)
					}
				}
				return zipStream.ToArray();
			}
		}
	}
