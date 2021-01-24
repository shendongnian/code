	public static string GetUniqueName(string fileName)
	{
		var dir = Globals.Directories.GetCustomCategoryThumbnailDir();
	
		var fileExtension = Path.GetExtension(fileName);
		var fileNameWE = Path.GetFileNameWithoutExtension(fileName);
		var files = Directory.GetFiles(dir, "*" + fileExtension)
			.Select(Path.GetFileName)
			.Where(w => w.StartsWith(fileNameWE)) // included condition.
			.ToArray();
	
		if (!files.Any()) return fileName;
		
		var pattern = fileNameWE
			.Select(s => "[" + s + "]")
			.Aggregate("", (ac, i) => ac + i);
		
		var regex = new Regex(pattern + @"[(](?<counter>\d)[)]");
		
		var previous = files
			.Select(file => regex.Match(file))
			.Where(match => match.Success)
			.OrderByDescending(match => int.Parse(match.Groups["counter"].Value))
			.FirstOrDefault();
		
		var correctIndex = previous != null
			? int.Parse(previous.Groups["counter"].Value) + 1
			: 1;
		
		return fileNameWE + "(" + correctIndex + ")" + fileExtension;
	}
