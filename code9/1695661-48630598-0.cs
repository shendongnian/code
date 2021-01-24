		var str = "Michael";
		var names = new List<string>() { "Michael", "Mich", "Micha", "M" };
		
        // get 80% of the string length
		var i = ((double) str.Length / 100) * 80;
		var x = Convert.ToInt32(i);
		
		foreach (var name in names)
		{
			if (name.Length >= i && name.Substring(0, x) == str.Substring(0, x))
			{
				Console.WriteLine(name);
			}
		}
