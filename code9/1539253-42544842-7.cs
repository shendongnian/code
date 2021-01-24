    foreach (var file in files)
	{
		if (refFiles.Any(pattern => Regex.IsMatch(file, pattern)))
		{
			Console.WriteLine(file);
		}
	}
