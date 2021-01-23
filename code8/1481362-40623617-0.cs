	int cnti = 0;
	var ignoreList = new List<string> { "a1", "a2", "a3", "a4" };
	string outputstring = string.Empty;
	foreach(string line in File.ReadLines("some.txt"))
	{
		if(cnti % 2 == 0)
			outputstring += line;
		else
			outputstring += string.Join(" ", line.Split().Where(w => !ignoreList.Contains(w)));
		outputstring += Environment.NewLine;
		cnti++;
	}
	File.WriteAllText("some.txt", outputstring);
	
