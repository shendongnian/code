    [FlagsAttribute] 
    public enum MyType 
    {
        a = 0,
        b = 1,
        c = 2,
        d = 4
    }
    public class Item
    {
        public string Id { get; set; }
        public MyType Type { get; set; }
    }
