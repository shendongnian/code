    int ComputeTypeHash<T>()
    {
        return typeof(T).GetProperties()
            .SelectMany(p => new[] { p.Name.GetHashCode(), p.PropertyType.GetHashCode() })
            .Aggregate(17, (h, x) => h * 23 + x);
    }
---
    ComputeTypeHash<Foo_v1>().Dump(); // 1946663838
    ComputeTypeHash<Foo_v2>().Dump(); // 1946663838
    ComputeTypeHash<Foo_v3>().Dump(); // 1985957629
    public class Foo_v1
    {
        public string Bar { get; set; }
    }
    public class Foo_v2
    {
        public string Bar { get; set; }
    }
    
    public class Foo_v3
    {
        public char[] Bar { get; set; }
    }
