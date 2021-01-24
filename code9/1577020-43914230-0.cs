    if (File.Exists(path))
	{
        string[] words = File.ReadAllLines(path);
		foreach (string line in words)
		{
			string [] elements = line.Split(' ');
			foreach (string elem in elements)
			{
				if (elem.StartsWith(toFind))
				{
					Console.WriteLine(line);
				}
			}
		}
	}
