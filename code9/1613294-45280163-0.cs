	string g = "Roses are red \r\nViolets are Blue";
		
	for (int i = g.Length -1; i >=  0; i--)
	{
		if (g[i] == '\n')
		{
			g = g.Insert(i, Environment.NewLine);
            // or as a string you can use your former logic
			g = g.Insert(i, "\r\n");
		}
	}
