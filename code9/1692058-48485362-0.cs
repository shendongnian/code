    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
	{
        static void Main(string[] args)
        {
            // ... do your normal setup "enter string etc"
            Console.WriteLine(array.Length);
            Dictionary<char, int> charToOccurancesMappings = str.ToCharArray().GroupBy(s => s).Select(g => new Occurances { Key = g.Key, Count = g.Count() }).ToDictionary(d => d.Key, d => d.Count);
            foreach (var mapping in charToOccurancesMappings)
		    {
 			    Console.WriteLine($"{mapping.Key} occured {mapping.Value} times");
		    }
        }
    }
    public class Occurances
	{
		public char Key { get; set; }
		public int Count { get; set; }
		public Occurances()
		{
		}
	}
