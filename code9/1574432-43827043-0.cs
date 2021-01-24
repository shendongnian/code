	Func<string, int?> tryParse = x =>
	{
		int r;
		if (int.TryParse(x, out r))
		{
			return r;
		}
		return null;
	};
	
	int highest =
		new DirectoryInfo(@"C:\Users\Public\BotMakerLoggerSite\Logs\" + token + @"\")
			.GetFiles()
			.Select(x => Path.GetFileNameWithoutExtension(x.Name))
			.Select(x => tryParse(x))
			.Where(x => x.HasValue)
			.Select(x => x.Value)
			.DefaultIfEmpty(0)
			.Max();
