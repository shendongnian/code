	public class Comparer : IComparer<string>
	{
		public int Compare(string a, string b) 
		{
			int ia = 0;
			int ib = 0;
			var aIsInt = int.TryParse(a,out ia);
			var bIsInt = int.TryParse(b,out ib);
			if (aIsInt == bIsInt)
			{
				if (aIsInt)
				{
					return ia.CompareTo(ib);
				}
				else
				{
					return a.CompareTo(b);
				}
			}
			return aIsInt ? -1 : 1;
		}
	}
