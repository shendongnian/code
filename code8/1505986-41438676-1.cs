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
    // add more values to the property
    typeItem.Type |= MyType.c
    var selected = items.Where(item => item.Type.HasFlag(MyType.a))
                        .Where(item => item.Type.HasFlag(MyType.b))
                        .Where(item => item.Type.HasFlag(MyType.c))
    // use selected values
    
