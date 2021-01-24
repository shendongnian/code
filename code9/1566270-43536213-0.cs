	public static IList<string> ChunkText(string text, int characterLimit)
	{
		List<string> parts = new List<string>();
		while (text.Length > 0)
		{
			if (text.Length <= characterLimit)
			{
				parts.Add(text);
				text = String.Empty;
			}
			else
			{
				int length = characterLimit;
				while (char.IsLetter(text[length])
						&& char.IsLetter(text[length - 1]))
				{
					length--;
				}
				parts.Add(text.Substring(0, length).Trim());
				text = text.Substring(length);
			}
		}
		return parts;
	}
		
	static void Main()
	{
		string text = "The quick brown fox jumped over the lazy dog.";
		IList<string> parts = ChunkText(text, 10);
		foreach (string part in parts)
		{
			Console.WriteLine(part);
		}
		Console.ReadLine();
	}
