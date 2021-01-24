		static string GetPassword(int length, int maxRepeats)
		{
			return new String
				(
					Enumerable.Range(0, maxRepeats)
				       .SelectMany( i => dictionary )
					   .OrderBy( a => _random.NextDouble() )
					   .Take(length)
					   .ToArray()
				);
		}
