	public static string ToPigLatin(string sentencetext)
	{
		string vowels = "AEIOUaeiou";
		string cons = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
	
		Func<string, string> toPigLatin = word =>
		{
			word = word.ToLower();
	
			var result = word;
	
			Func<string, string, (string, string)> split = (w, l) =>
			{
				var prefix = new string(w.ToArray().TakeWhile(x => l.Contains(x)).ToArray());
				return (prefix, w.Substring(prefix.Length));
			};
	
			if (!word.Any(w => cons.Contains(w)))
			{
				result = word + "way";
			}
			else
			{
				var (s, e) = split(word, vowels);
				var (s2, e2) = split(e, cons);
				result = e2 + s + s2 + "ay";
			}
			return result;
		};
	
		return string.Join(" ", sentencetext.Split(' ').Select(x => toPigLatin(x)));
	}
