    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
	{
        static void Main(string[] args)
        {
            // ... do your normal setup "enter string etc"
            Console.WriteLine(array.Length);
            Dictionary<char, int> charToOccurencesMappings = str.ToCharArray().GroupBy(s => s).Select(g => new Occurences { Key = g.Key, Count = g.Count() }).ToDictionary(d => d.Key, d => d.Count);
            foreach (var mapping in charToOccurencesMappings)
		    {
 			    Console.WriteLine($"{mapping.Key} occured {mapping.Value} times");
		    }
        }
    }
    public class Occurences
	{
		public char Key { get; set; }
		public int Count { get; set; }
		public Occurences()
		{
		}
	}
