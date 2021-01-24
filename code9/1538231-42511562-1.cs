    public static class IntExt
    {
        public static int? ParseNullable(string text)
    	{
	    	int result;
		    return int.TryParse(text, out result) ? result : (int?)null;
    	}
    }
