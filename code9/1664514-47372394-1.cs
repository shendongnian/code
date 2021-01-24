	public static bool IsPalindrome(string s)
	{
		return IsPalindrome(s, 0, s.Length - 1);
	}
	
	private static bool IsPalindrome(string s, int start, int finish)
	{
		if (finish - start <= 0)
		{
			return true;
		}
		else
		{
			if (s[start] != s[finish])
			{
				return false;
			}
			else
			{
				return IsPalindrome(s, start + 1, finish - 1);
			}
		}
	}
