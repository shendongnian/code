    var selected = items.Where(item => item.Type.HasFlag(MyType.a))
                        .Where(item => item.Type.HasFlag(MyType.b))
                        .Where(item => item.Type.HasFlag(MyType.c))
    // use selected values
    
