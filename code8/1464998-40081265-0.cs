    using System;
    using System.Collections.Generic;
    using System.Linq;
					
    public class Program
    {
    	public static void Main()
    	{
    		string[] movies = {
    			"Star Wars Episode IV A New Hope",
    			"Force of Hunger",
    			"The Hunger Games Mockingjay",
    			"Jaws 2",
    			"The Shawshank Redemption",
    			"Hunger Pain",
    			"The Hunger Games",
    			"Jaws: The Revenge",
    			"The Hunger Games Catching Fire",
    			"Rogue One A Star Wars Story",
    			"Aqua Teen Hunger Force",
    			"The Force Awakens Star Wars",
    		};
    		
    		List<HashSet<string>> titleWords = movies
    			.Select(m => new HashSet<string>(
    				m.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries)
    				.Select(w => w.ToLower())
    				.Where(w => w != "a" && w != "an" && w != "the")))
    			.ToList();
    		
    		var titles = new Dictionary<string, SortedSet<Commonality>>();
    		for (int i = 0; i < titleWords.Count; i++)
    		{
    			for (int j = i + 1; j < titleWords.Count; j++)
    			{
    				var wordsInCommon = titleWords[i]
    					.Intersect(titleWords[j])
    					.OrderBy(w => w)
    					.ToList();
    				Commonality c = new Commonality(wordsInCommon);
    				AddCommonalities(titles, movies[i], c);
    				AddCommonalities(titles, movies[j], c);
    			}
    		}
    		
    		string[] groupedTitles = titles
    			.OrderBy(k => k.Value.First())
    			.ThenBy(k => k.Key)
    			.Select(k => k.Key)
    			.ToArray();
    		
    		Console.WriteLine(string.Join("\r\n", groupedTitles));
    	}
    	
    	private static void AddCommonalities(Dictionary<string, SortedSet<Commonality>> dict, string title, Commonality c)
    	{
    		SortedSet<Commonality> commonalities;
    		if (!dict.TryGetValue(title, out commonalities))
    		{
    			commonalities = new SortedSet<Commonality>();
    			dict.Add(title, commonalities);
    		}
    		if (!commonalities.Contains(c))
    		{
    			commonalities.Add(c);
    		}
    	}
    }
    
    class Commonality : IComparable<Commonality>
    {
    	public string JoinedWords { get; private set; }
    	public int WordCount { get; private set; }
    	
    	public Commonality(List<string> words)
    	{
    		JoinedWords = string.Join(" ", words);
    		WordCount = words.Count;
    	}
    	
    	public override bool Equals(object obj)
    	{
    		Commonality that = obj as Commonality;
    		return (that != null && that.JoinedWords == JoinedWords);
    	}
    	
    	public override int GetHashCode()
    	{
    		return JoinedWords.GetHashCode();
    	}
    	
    	public int CompareTo(Commonality other)
    	{
    		int r = other.WordCount - WordCount;
    		if (r == 0) return string.CompareOrdinal(JoinedWords, other.JoinedWords);
    		return r;
    	}
    	
    	public override string ToString()
    	{
    		return WordCount + " " + JoinedWords;
    	}
    }
