		string[] Paths = Directory.GetFiles(path, "*.txt");
		string[] stripchars1 = { "<", "?", "." };
		string[] chars2 = { "s", "w", "n" };
	
		foreach (string file in Paths)
		{
			var text = File.ReadAllText(file);
	
			foreach (string character in stripchars1)
			{
				text = text.Replace(character, " ");
			}
	
			foreach (string character in chars2)
			{
				text = text.Replace(character, "h");
			}
	
			File.WriteAllText(file, text);
		}
