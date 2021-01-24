	var pattern = "D";
	while (!stRead.EndOfStream)
	{
		line+= stRead.ReadLine();
		
		if (!string.IsNullOrEmpty(line))
		{
			var matches = Regex.Matches(line, @"^\d{4}-\d{2}-(\d{2,3})\sproductkey=([\w;]*)");
			if (matches.Count > 0)
			{
				var day = matches[0].Groups[1].Value;
				var productKey = matches[0].Groups[2].Value;
				var count = Regex.Matches(productKey, pattern).Count;
				text += string.Format("{0} - {1}{2}", day, count, Environment.NewLine);
			} 
		}
	}
	TextBox1.Text = text;
