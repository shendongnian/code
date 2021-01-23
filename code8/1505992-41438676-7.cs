    [FlagsAttribute] 
    public enum MyType 
    {
        a = 1,
        b = 2,
        c = 4,
        d = 8
    }
    public class Item
    {
        public string Id { get; set; }
        public MyType Type { get; set; }
    }
