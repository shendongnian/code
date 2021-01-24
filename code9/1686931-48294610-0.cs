    static class StringExtensions
    {
    	public static int ImaginaryIndexOf(this string input, IEnumerable<string> searchFor)
	    {
		    return (int)searchFor
                .Select
                (
                    s => (uint)input.IndexOf(s) 
                )
                .Min();
    	}
    }
