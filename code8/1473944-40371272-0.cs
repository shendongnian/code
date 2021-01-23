	public string ExactReplace(string input, string find, string replace)
    {
        string textToFind = string.Format(@"\b{0}\b", find);
        return Regex.Replace(input, textToFind, replace);
    }
	
