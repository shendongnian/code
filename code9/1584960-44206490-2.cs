    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string str = "you androids don't exactly cover for each other in times of stress. i think youre right it would seem we lack a specific talent you humans possess i believe it's called empathy"; 
    		var sList = new List<string> {"for each other", "other in", "talent", "you humans", "you"};
    		var chRangeMap = new bool[str.Length];
    		for (var i = 0; i < chRangeMap.Length; ++i) chRangeMap[i] = false;
    		
    		var matchedTokenMap = sList
    			.Select(i => "\\b" + Regex.Escape(i) + "\\b")
    			.SelectMany(p => (new Regex(p)).Matches(str).OfType<Match>())
    			.Cast<Match>()
    			.Select(m => new 
    					{ 
    						StartIndex = m.Index,
    						EndIndex = m.Index + m.Length,
    						Length = m.Length
    					})
    			.Select(r => {
    				for (var i = r.StartIndex; i < r.EndIndex; ++i) chRangeMap[i] = true;
    				return r;
    				});
    		
    		var fullTokenized = 
    			matchedTokenMap.Concat(
    				GetArrayRanges(chRangeMap, false)
    					.Select(r => new 
    							{ 
    								StartIndex = r.Item1,
    								EndIndex = r.Item2,
    								Length = r.Item2 - r.Item1
    							})
    			)
    			.OrderBy(k => k.StartIndex).ThenBy(sk => sk.Length);
    		
    		foreach(var token in fullTokenized)
    		{
    			WriteTrimmed(str.Substring(token.StartIndex, token.Length));
    		}
    	}
    	
    	private static void WriteTrimmed(string str)
    	{
    		str = str.Trim();
    		if (!string.IsNullOrWhiteSpace(str))
    		{
    			Console.WriteLine(str);
    		}
    	}
    	
    	private static IEnumerable<Tuple<int, int>> GetArrayRanges(bool[] array, bool seekValue)
    	{
    		int? rangeStart = null;
    		
    		for(var i = 0; i < array.Length; ++i)
    		{
    			if (array[i] == seekValue)
    			{
    				if (!rangeStart.HasValue)
    				{
    					rangeStart = i;
    				}
    			}
    			else
    			{
    				if (rangeStart.HasValue)
    				{
    					yield return Tuple.Create(rangeStart.Value, i);
    					rangeStart = null;
    				}
    			}
    		}
    		
    		if (rangeStart.HasValue)
    		{
    			yield return Tuple.Create(rangeStart.Value, array.Length);
    		}
    	}
    }
