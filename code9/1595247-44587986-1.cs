    private static string FindBookEanOrEanOnSplits(string[] splits)
	{
		string id = "";
		for (int i = 0; i < 3; i++)
		{
			id = Extractor.ExtractBookEanOrEan(splits[index].ToUpper());
            if (!string.IsNullOrEmpty(id)) break;
		}
		return id;
	}
