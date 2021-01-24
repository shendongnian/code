    internal class FileParser
	{
		internal Dictionary<string, string> WordDictionary = new Dictionary<string, string>();
		private string _filePath;
		private char Seperators => ',';
		internal FileParser(string filePath)
		{
			_filePath = filePath;
		}
		internal void Parse()
		{
			StreamReader sr = new StreamReader(_filePath);
			string TxtWrd = sr.ReadLine();
			while ((TxtWrd = sr.ReadLine()) != null)
			{
				var words = TxtWrd.Split(Seperators, StringSplitOptions.None);
				//WordDictionary.TryAdd(Words[0], Words[1]); // available in .NET corefx https://github.com/dotnet/corefx/issues/1942
				if (!WordDictionary.ContainsKey(words[0]))
					WordDictionary.Add(words[0], words[1]);
			}
		}
		internal bool IsWordAvailable(string word)
		{
			return WordDictionary.ContainsKey(word);
		}
	}
