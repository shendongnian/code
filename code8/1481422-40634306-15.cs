	List<string> newLines = new List<string>();
    using(System.IO.StreamReader file = new System.IO.StreamReader(@"/path/to/file.txt"))
	{
		int x = 0;
		while((line = file.ReadLine()) != null)
		{
			if(x % 2 == 1 && newLines.Contains(lines[x])) //is odd and already exists
				x++; \\skip next even line
			else
				newLines.Add(lines[x]);
			x++;
		}
	}
