    public class DictionaryComparer
    {
        public List<string> CompareDictionaries(IDictionary<string, double> first, IDictionary<string, double> second)
        {
            var dictionary  = new Dictionary<string, int>();
            foreach (var f in first)
            {
                if (!dictionary.ContainsKey(f.Key))
                {
                    dictionary.Add(f.Key, 1);
                }
                else
                {
                    dictionary[f.Key]++;
                }
            }
            foreach (var f in second)
            {
                if (!dictionary.ContainsKey(f.Key))
                {
                    dictionary.Add(f.Key, 1);
                }
                else
                {
                    dictionary[f.Key]++;
                }
            }
            return dictionary.Where(s => s.Value == 1).Select(a => a.Key).ToList();
        }
    }
