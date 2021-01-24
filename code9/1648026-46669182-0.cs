	using (TextFieldParser parser = new TextFieldParser(newestFile.FullName))
	{
		parser.Delimiters = ","
		parser.HasFieldsEnclosedInQuotes = true;
		while (!parser.EndOfData)
		{
			try
			{
				List<string> result = parser.ReadFields().ToList();
				// do something 
			}
			catch(MalformedLineException ex)
			{
				int errorLine = parser.ErrorLineNumber;
				string originalData =  parser.ErrorLine;
				// log them
			}   
		}
	}
