	public static string MyReverseString(string s)
	{
		return MyReverseString(s, s.Length - 1);
	}
	
	private static string MyReverseString(string s, int index)
	{
		if (index > 0)
		{
			return s[index] + MyReverseString(s, index - 1);
		}
		else
		{
			return s[index].ToString();
		}
	}
