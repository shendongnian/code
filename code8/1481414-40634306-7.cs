			string[] lines = System.IO.File.ReadAllLines("/path/to/file.txt");
			List<string> newLines = new List<string>();
        	for(int x = 0; x < lines.Length; x++)
			{
				if(x % 2 == 1 && newLines.Contains(lines[x]))
					x++;
				else
					newLines.Add(lines[x]);
			}
