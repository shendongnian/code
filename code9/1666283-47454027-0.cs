    public static List<string> HocusPocus(Dictionary<string, HashSet<string>> data)
    {
        var invert = new Dictionary<string, HashSet<string>>();
        foreach (var kvp in data)
        {
            foreach (var s in kvp.Value)
            {
                if (!invert.TryGetValue(s, out var pvalues))
                {
                    pvalues = new HashSet<string>();
                    invert[s] = pvalues;
                }
                pvalues.Add(kvp.Key);
            }
        }
            
        var lookup = invert
            .ToLookup(_ => _.Value, _ => _.Key, new SetComparer());
            
        var flat = new List<string>();
        foreach (var item in lookup)
        {
            flat.AddRange(item.Key);
            flat.AddRange(item);
        }
        return flat;
    }
    public class SetComparer : IEqualityComparer<ISet<string>>
    {
        public bool Equals(ISet<string> x, ISet<string> y)
        {
            return x.SetEquals(y);
        }
        public int GetHashCode(ISet<string> obj)
        {
            unchecked
            {
                int hash = 19;
                foreach (var foo in obj)
                {
                    hash = hash * 31 + foo.GetHashCode();
                }
                return hash;
            }
        }
    }
