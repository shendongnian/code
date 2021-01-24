    using (TextFieldParser parser = new TextFieldParser(csvFilePath))
	{
		Dictionary<string, CustomRecord> csvDictionary = new Dictionary<string, CustomRecord>();
		parser.TextFieldType = FieldType.Delimited;
		parser.SetDelimiters(",");
		while (!parser.EndOfData)
		{
			//write to custom record
		}
