      private static string MakeKey(string value) {
        return string.Concat(value
          .Select(c => char.ToUpper(c)) // let's be case insensitive
          .OrderBy(c => c));
      }
      private static void AddWord(Dictionary<string, HashSet<string>> words, string word) {
        string key = MakeKey(word);
        HashSet<string> anagrams; 
       
        if (words.TryGetValue(key, out anagrams))
          anagrams.Add(word);
        else 
          words.Add(key, new HashSet<string>() {word});            
      }
      ...
      
      Dictionary<string, HashSet<string>> words = new Dictionary<string, HashSet<string>>(); 
      string[] initialWords = { 
        "Elg", "mammut", "gel", "ram", "era", "arm", "rea", "för", "frö" };
        
      foreach (var word in initialWords) 
        AddWord(words, word);
