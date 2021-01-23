		Func<string, string[]> getDirectories = dir =>
		{
			try
			{
				return Directory.GetDirectories(dir);
			}
			catch (UnauthorizedAccessException uae)
			{
				unauthorized.Add(uae.Message);
				return new string[] { };
			}
		};
		emptyFolders =
			EnumerableEx
				.Expand(getDirectories(rootPath), dir => getDirectories(dir))
				.Where(dir => Directory.GetFiles(dir).Length == 0 && getDirectories(dir).Length == 0)
				.ToList();
