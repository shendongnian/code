	Parser nOb = new Parser(yourText);
    var result = nOb.Find();
	string parsed = string.Empty;
    if (!result.Any())
    {
		// Nothing found
    }
    else
    {
        var stringBuilder = new StringBuilder();
		foreach (var line in result)
		{
			stringBuilder.AppendLine(line);
		}
		parsed = stringBuilder.ToString();
		
        // ...parsed
    }
