	using (TextFieldParser csvReader = new TextFieldParser(@"C:\temp\temp.csv", Encoding.GetEncoding("windows-1252")))
	{
		csvReader.SetDelimiters(new string[] { "\";" });
		csvReader.HasFieldsEnclosedInQuotes = false;
		while (!csvReader.EndOfData)
		{
			string[] fieldData = csvReader.ReadFields();
			for (int i = 0; i < fieldData.Length; i++)
			{
				if (fieldData[i] == "")
				{
					fieldData[i] = null;
				}
			}
			fieldData.Dump();
		}
	}
