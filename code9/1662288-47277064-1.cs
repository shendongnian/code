	using System;
	using System.Collections.Generic;
	public class Program
	{
		public static void Main()
		{
			var words = new[] { "COMPUTE", "FIVE", "CODE", "COLOR", "PUT", "EMERGENCY", "MERGE", "EMERGE" };
			var trie = new Trie(words);
			var input = "COMPUTEEMERGEFIVECODECOLOR";
			for (var charIndex = 0; charIndex < input.Length; charIndex++)
			{
				var longestWord = FindLongestWord(trie.Root, input, charIndex);
				if (longestWord == null)
				{
					Console.WriteLine("No word found at char index {0}", charIndex);
				}
				else
				{
					Console.WriteLine("Found {0} at char index {1}", longestWord, charIndex);
					charIndex += longestWord.Length - 1;
				}
			}
		}
		static private string FindLongestWord(Trie.Node node, string input, int charIndex)
		{
			var character = char.ToUpper(input[charIndex]);
			string longestWord = null;
			foreach (var edge in node.Edges)
			{
				if (edge.Key.ToChar() == character)
				{
					var foundWord = edge.Value.Word;
					if (!edge.Value.IsTerminal)
					{
						var longerWord = FindLongestWord(edge.Value, input, charIndex + 1);
						if (longerWord != null) foundWord = longerWord;
					}
					if (foundWord != null && (longestWord == null || edge.Value.Word.Length > longestWord.Length))
					{
						longestWord = foundWord;
					}
				}
			}
			return longestWord;
		}
	}
	//Trie taken from: https://stackoverflow.com/a/6073004
	public struct Letter
	{
		public const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public static implicit operator Letter(char c)
		{
			return new Letter() { Index = Chars.IndexOf(c) };
		}
		public int Index;
		public char ToChar()
		{
			return Chars[Index];
		}
		public override string ToString()
		{
			return Chars[Index].ToString();
		}
	}
	public class Trie
	{
		public class Node
		{
			public string Word;
			public bool IsTerminal { get { return Edges.Count == 0 && Word != null; } }
			public Dictionary<Letter, Node> Edges = new Dictionary<Letter, Node>();
		}
		public Node Root = new Node();
		public Trie(string[] words)
		{
			for (int w = 0; w < words.Length; w++)
			{
				var word = words[w];
				var node = Root;
				for (int len = 1; len <= word.Length; len++)
				{
					var letter = word[len - 1];
					Node next;
					if (!node.Edges.TryGetValue(letter, out next))
					{
						next = new Node();
					
						node.Edges.Add(letter, next);
					}
					if (len == word.Length)
					{
						next.Word = word;
					}
					node = next;
				}
			}
		}
	}
