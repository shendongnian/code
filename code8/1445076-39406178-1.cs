	void Main()
	{
		var words = File.ReadLines("FileA.txt").SelectMany(x => new[] { x, x + "00" });
	
		var trie = new Trie(words);
	
		var query = from word in File.ReadLines("FileB.txt")
					where trie.Contains(word)
					select word;
	
		File.WriteAllLines("output.txt", query);
	}
	
	public class Trie : Dictionary<char, Trie>
	{
		public Trie() : base(0) { }
		public Trie(IEnumerable<string> words) : base(0)
		{
			foreach (var word in words)
			{
				this.Add(word);
			}
		}
	
		public void Add(string word)
		{
			if (String.IsNullOrEmpty(word))
			{
				this[char.MinValue] = null;
			}
			else
			{
				Trie t = null;
				if (this.ContainsKey(word[0]))
				{
					t = this[word[0]];
				}
				else
				{
					t = new Trie();
					this[word[0]] = t;
				}
				t.Add(word.Substring(1));
			}
		}
	
		public bool Contains(string prefix)
		{
			return this.ContainsInternal(prefix + char.MinValue);
		}
		
		private bool ContainsInternal(string prefix)
		{
			if (!string.IsNullOrEmpty(prefix) && this.ContainsKey(prefix[0]))
			{
				return prefix.Length == 1 || this[prefix[0]].ContainsInternal(prefix.Substring(1));
			}
			return false;
		}
	}
