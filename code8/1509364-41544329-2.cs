	StringBuilder sb = new StringBuilder();
	StringBuilder partBuilder = new StringBuilder(); 
	int partsSplitted = 0;
	for (int i = 1; i <= input.Length; i++)
	{
		partBuilder.Append(input[i-1]);
		if (i % 3 == 0 && partsSplitted<=3)
		{
			sb.Append(' ');
			sb.Append(partBuilder.ToString());
			partBuilder = new StringBuilder();
			partsSplitted++;
		}
	}
	sb.Append(partBuilder.ToString());
    string formatted = sb.ToString().TrimStart();
