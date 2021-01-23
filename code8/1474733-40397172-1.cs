	List<string> a = File.ReadAllLines(path).ToList();
	List<string> b = File.ReadAllLines(newPath).ToList();
	using (var myWriter1 = new StreamWriter(resultpath, false))
	{
		foreach (string s in a)
		{
			Console.WriteLine(s);
			if (!b.Contains(s))
				myWriter1.WriteLine(s);
		}
	}
	string[] resultfile = File.ReadAllLines(resultpath);
	if (resultfile == null || resultfile.Length == 0)
	{
		using (var myWriter1 = new StreamWriter(resultpath, true))
		{
			myWriter1.WriteLine("Der er ikke nogen udmeldinger idag", true);
		}
	}
