        public string GetPartialWord(string word)
		{
			if(string.IsNullOrEmpty(word))
			{
				return string.Empty;
			}
			char[] partialWord = word.ToCharArray();
			int numberOfCharsToHide = word.Length / 2;
			Random randomNumberGenerator = new Random();
			HashSet<int> maskedIndices = new HashSet<int>();
			for(int i=0;i<numberOfCharsToHide;i++)
			{
				int rIndex = randomNumberGenerator.Next(0, word.Length);
				while(!maskedIndices.Add(rIndex))
				{
					rIndex = randomNumberGenerator.Next(0, word.Length);
				}
				partialWord[rIndex] = '_';
			}
			return new string(partialWord);
		}
