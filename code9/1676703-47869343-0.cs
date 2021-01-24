	IEnumerable<string> readInLines = File.ReadAllLines(sourcefile);
	bool started = false;
	List<string> results = new List<string>();
	foreach(var line in readInLines)
	{
		if(emptyElement(line))
			continue;
		if(hyphens72(line))
		{
			// flip state.. (start/end)
			started != started;
		}
		
		if(started)
		{
			// I don't know what you are doing here precisely, do what you gotta do. ;-)
			results.AddRange((line.Split('|').Select(p => p.Trim()).ToList()));
			string holderCP = string.Join(Environment.NewLine, readInLines, holderCPStart, (blankLine - holderCPStart - 1)).Trim();
			results.Add(holderCP);
			string comment = string.Join(" ", readInLines, blankLine + 1, (endDiv - (blankLine + 1)));//in case the comment is more than one line long
			results.Add(comment);
		}
	}
	foreach (string result in results)
	{
		Console.WriteLine(result);
	}
