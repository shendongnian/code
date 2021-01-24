    class Program
	{
		static void Main(string[] args)
		{
			var res = AlternateCharCases("cat");
			foreach (var r in res)
				Console.WriteLine(r);
			Console.ReadKey();
		}
		public static List<string> AlternateCharCases(string lowercaseWord)
		{
			var result = new List<string>();
			AlternateCharCases(lowercaseWord, lowercaseWord.ToCharArray(), 0, result);
			result = result.Distinct().ToList();
			return result;
		}
		static void AlternateCharCases(string initialWord, char[] word, int startIndex, List<string> result)
		{
			if (startIndex == word.Length)
				result.Add(new string(word));
			else
			{
				if(!Char.IsLetter(initialWord[startIndex]))
				{
					word[startIndex] = initialWord[startIndex];
					AlternateCharCases(initialWord, word, startIndex + 1, result);
				}
				else
				{
					word[startIndex] = initialWord[startIndex];
					AlternateCharCases(initialWord, word, startIndex + 1, result);
					word[startIndex] = Char.ToUpper(initialWord[startIndex]);
					AlternateCharCases(initialWord, word, startIndex + 1, result);
				}
			}
			
		}
	}
