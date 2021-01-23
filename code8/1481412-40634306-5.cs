			string text = System.IO.File.ReadAllLines("/path/to/file.txt");
			
			string[] lines = text.Split(new string[] { "\n", "\r" }, System.StringSplitOptions.RemoveEmptyEntries);
			List<string> newLines = new List<string>();
        	for(int x = 0; x < lines.Length; x++)
			{
				if(x % 2 == 1 && newLines.Contains(lines[x]))
				{
					x++;
					continue;
				}
				newLines.Add(lines[x]);
			}
