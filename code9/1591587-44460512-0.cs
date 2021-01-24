	public int GetNumFromList<T>(IEnumerable<T> list, T eType)
		 where T : struct, IComparable, IFormattable, IConvertible
	
	{
		return list.Count(x => x.Equals(eType));
	}
