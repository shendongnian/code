    public static class StringUtils
    {
    	public static unsafe string UnsafeSubstring(this string source, int startIndex, int length)
    	{
    		fixed (char* chars = source)
    			return new string(chars, startIndex, length);
    	}
    }
