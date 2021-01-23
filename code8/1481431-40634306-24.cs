    //Delete file if exists
	if(System.IO.File.Exists(@"/path/to/new_file.txt"))
		System.IO.File.Delete(@"/path/to/new_file.txt")
	List<string> newLines = new List<string>();
    using (System.IO.StreamReader file = new System.IO.StreamReader(@"/path/to/file.txt"))
	using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"/path/to/new_file.txt", true))
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
			    writer.WriteLine(line);
			}
			x++;
		}
	}
