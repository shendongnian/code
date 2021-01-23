    using System;
	using System.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			
			var letters = new HashSet<char>("sopitez");
		
			var wordsMap = new Dictionary<string, int>()
			{
				{"some", 6}, {"first", 8}, {"potsie", 8}, {"postie", 8}, {"day", 7},
				{"could", 8}, {"from", 9}, {"have", 10}, {"back", 12},
				{"this", 7}
			};
		
			var highest = wordsMap
				.Select(kvp => {
					var word = kvp.Key;
					var points = kvp.Value;
					var matchCount = kvp.Key.Sum(c => letters.Contains(c) ? 1 : 0);
					return new {
						Word = word,
						Points = points,
						MatchCount = matchCount,
						FullMatch = matchCount == word.Length,
						EstimatedScore = points * matchCount /(double) word.Length // This can vary... it's just my guess for an "Estiamted score"
					};
				})
				.OrderByDescending(x => x.FullMatch)
				.ThenByDescending(x => x.EstimatedScore);
				
			foreach (var anon in highest)
			{
				Console.WriteLine("{0}", anon);
			}		
			
		}
	}
