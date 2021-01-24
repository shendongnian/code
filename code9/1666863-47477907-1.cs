	public string SearchY(RichTextBox richt, string key, int i, string stop)
	{
		string source = richt.Text;
		int _StartIndex = source.IndexOf(key) + i;
		string extract = _StartIndex < source.Length ? source.Substring(_StartIndex) : source;
		string result = extract.Substring(0, extract.IndexOf(stop));
		int _Length = extract.IndexOf(stop);
		result = _Length > extract.Length ? extract.Substring(0, _Length) : extract;
		return result;
	}
