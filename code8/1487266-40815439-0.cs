	private static async Task<IList<byte>> GetChecksums()
	{
		var bytes = new List<byte>();
		foreach (var path in Directory.EnumerateFiles("FolderWithZips"))
		{
			using (var archive = CreateZipArchive(path))
			{
				foreach (var entry in archive.Entries)
				{
					using (var stream = entry.Open())
					{
						var checksum = await CalculateChecksum(stream, entry.Length);
						bytes.Add(checksum);
					}
				}
			}
		}
	
		return bytes;
	}
