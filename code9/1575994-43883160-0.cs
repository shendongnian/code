    using Microsoft.VisualBasic.FileIO;
    ...
    string str = "\"AAC\",\"AAC Holdings, Inc.\"";			
	List<string[]> param = new List<string[]>();
	string[] words; //add intermediary reference
	using (TextFieldParser parser = new TextFieldParser(new StringReader(str))) {
		parser.Delimiters = new string[] { "," }; //the parameter must be comma
		parser.HasFieldsEnclosedInQuotes = true; //VERY IMPORTANT
		while ((words = parser.ReadFields()) != null)
			param.Add(words);
	}
	foreach (var par in param)
		Console.WriteLine(string.Join("; ", par));
