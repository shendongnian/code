    public class TagDictionary
    {
        Dictionary<string, HashSet<string>> _innerStorage = new Dictionary<string, HashSet<string>>();
        public void Add(IEnumerable<string> tags, string value)
        {
            foreach (var tag in tags)
            {
                if (_innerStorage.ContainsKey(tag))
                {
                    var hash = _innerStorage[tag];
                    if (!hash.Contains(value))
                    {
                        hash.Add(value);
                    }
                }
                else
                {
                    _innerStorage[tag] = new HashSet<string>
                    {
                        value
                    };
                }
            }
        }
        public HashSet<string> GetValuesByTags(IEnumerable<string> tags)
        {
            var result = new HashSet<string>();
            foreach (var tag in tags)
            {
                if (_innerStorage.ContainsKey(tag))
                {
                    result.UnionWith(_innerStorage[tag]);
                }
            }
            return result;
        }
    }
