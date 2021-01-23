	void Main()
	{
		var myList = new List<Article>
		{
			new Article {Position = "1", Info = "test1"},
			new Article {Position = "2", Info = "test2"},
			new Article {Position = "3", Info = "test3"},
			new Article {Position = "4", Info = "test4"},
			new Article {Position = "4B", Info = "test5"},
			new Article {Position = "4A", Info = "test6"}
		};
			
		myList.OrderBy(x => x.Position, new CustomComparer()).ToList();
	}
	
	public class CustomComparer : IComparer<string>
	{
		Comparer _comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);
	
		public int Compare(string x, string y)
		{
			string numxs = string.Concat(x.TakeWhile(c => char.IsDigit(c)).ToArray());
			string numys = string.Concat(y.TakeWhile(c => char.IsDigit(c)).ToArray());
	
			int xnum;
			int ynum;
			if (!int.TryParse(numxs, out xnum) || !int.TryParse(numys, out ynum))
			{
				return _comparer.Compare(x, y);
			}
			int compareNums = xnum.CompareTo(ynum);
			if (compareNums != 0)
			{
				return compareNums;
			}
			return _comparer.Compare(x, y);
		}
	}
