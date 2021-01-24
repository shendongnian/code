    public class StringArrayValueComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
            => x.SequenceEqual(y);
        public int GetHashCode(List<string> obj)
            => obj.Aggregate(1, (current, s) => current * 31 + s.GetHashCode());
    }
    var list = new List<List<string>>(new[]
    {
        new List<string>(new [] { "a","b","c" }),
        new List<string>(new [] { "d","e","f" }),
        new List<string>(new [] { "a","b" }),
        new List<string>(new [] { "a", "b", "c" }),
        new List<string>(new [] { "a", "b", "c" }),
        new List<string>(new [] {"a","b"})
    });
    var priority = list
        .GroupBy(x => x, x => x, (x, enumerable) => new { Key = x, Count = enumerable.Count()}, new StringArrayValueComparer())
        .OrderByDescending(x => x.Count)
        .ToDictionary(x => x.Key, x => x.Count);
