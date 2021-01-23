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
        public MyType Type { get; set; }
    }
    var typeItem = new Item
    {
        Type = MyType.a | MyType.b
    }
    var selected = types.Where(type => type.MyType.HasFlag(MyType.a))
                        .Where(type => type.MyType.HasFlag(MyType.b))
                        .Where(type => type.MyType.HasFlag(MyType.c))
    // use selected values
    
