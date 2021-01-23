	List<string> newLines = new List<string>();
    using(System.IO.StreamReader file = new System.IO.StreamReader(@"/path/to/file.txt"))
	{
        string line = null;
		int x = 0;
		while((line = file.ReadLine()) != null)
		{
			if(x % 2 == 1 && newLines.Contains(line)) //is odd and already exists
				x++; \\skip next even line
			else
			{
				newLines.Add(line);
			    System.IO.File.AppendAllText(@"/path/to/new_file.txt", line + System.Environment.NewLine);
			}
			x++;
		}
	}
