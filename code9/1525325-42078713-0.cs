    class DateComparer : IComparer<string>
    {
    	public int Compare(string a, string b)
    	{
    		var a_date = DateTime.ParseExact(a, "MM/yyyy", null);
    		var b_date = DateTime.ParseExact(b, "MM/yyyy", null);
    		return a_date.CompareTo(b_date);
    	}
    }
