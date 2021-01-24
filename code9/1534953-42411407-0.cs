	public static bool Palindrome(string word)
	{
		var w = word.ToLowerInvariant();
		return w.Zip(w.Reverse(), (x, y) => x == y).Take(word.Length / 2).All(x => x);
	}
