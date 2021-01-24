    public class SynonymReplacer
        {
            private Dictionary<string, List<string>> _synonyms;
    
            public void Load(string s)
            {
                _synonyms = new Dictionary<string, List<string>>();
                var lines = s.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var words = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                    words.ForEach(word => _synonyms.Add(word, words));
                }
            }
    
            public string Replace(string word)
            {
                if (_synonyms.ContainsKey(word))
                {
                    return _synonyms[word].FirstOrDefault(w => w != word) ?? word;
                }
                return word;
            }
        }
