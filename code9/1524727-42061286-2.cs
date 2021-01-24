    public class LexicoComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			var firstArgumentSplits = x.Split(' ');
			var secondArgumentSplits = y.Split(' ');
			if (firstArgumentSplits.Length == 2 && secondArgumentSplits.Length == 2)
			{
				int firstArgumentInt, secondArgumentInt;
				if (firstArgumentSplits[0] == secondArgumentSplits[0])
				{
					if (int.TryParse(firstArgumentSplits[1], out firstArgumentInt))
					{
						if (int.TryParse(secondArgumentSplits[1], out secondArgumentInt))
						{
							return firstArgumentInt == secondArgumentInt ? 0 : firstArgumentInt > secondArgumentInt ? 1 : 0;
						}
					}
				}
			}
			
			return String.Compare(x, y);
		}
	}
