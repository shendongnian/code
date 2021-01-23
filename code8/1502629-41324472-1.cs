	class my_object
	{
		class Coordinates
		{
			public int _column = 0;
			public int _row = 0;
			public Coordinates(int row, int column)
			{
				_column = column;
				_row = row;
			}
		}
		List<List<string>> columns = new List<List<string>>(4);
		Dictionary<string, List<Coordinates>> searchIndex = new Dictionary<string, List<Coordinates>>();
		public my_object()
		{
			for (int i = 0; i < columns.Count; i++)
			{
				columns[i] = new List<string>();
			}
		}
        //This will create entries for each consecutive substring in each word that you add.
		public void AddWord(string word, int column)
		{
			for (int i = 0; i < word.Length; i++)
			{
				int limit = word.Length - i;
				for (int j = 1; j < limit; j++)
				{
					string temp = word.Substring(i, j);
					if (!searchIndex.ContainsKey(temp))
					{
						searchIndex.Add(temp, new List<Coordinates>());
					}
					searchIndex[temp].Add(new Coordinates(columns.Count, column));
				}
			}
			columns[column].Add(word);
		}
        //This will return a list of list of strings that contain the search term.
		public List<List<string>> Find(string term)
		{
			List<List<string>> outVal = new List<List<string>>(4);
			if(searchIndex.ContainsKey(term))
			{
				foreach(Coordinates c in searchIndex[term])
				{
					outVal[c._column].Add(columns[c._column][c._row]);
				}
			}
			return outVal;
		}
	}
