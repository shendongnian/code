    static Func<object,object> CreateDelegate(PropertyInfo[] path)
    {
        var rootType = path.First().DeclaringType;
        var param = Expression.Parameter(typeof(object));
        Expression access = Expression.Convert(param, rootType);
        foreach (var prop in path)
        {
            access = Expression.MakeMemberAccess(access, prop);
        }
    
        var lambda = Expression.Lambda<Func<object, object>>(
            Expression.Convert(access, typeof(object)),
            param
        ).Compile();
    
        return lambda;
    }
    
    static void Main(string[] args)
    {
        var path = new[]
        {
            typeof(Root).GetProperty("Level1"),
            typeof(Level1).GetProperty("Level2"),
            typeof(Level2).GetProperty("Name")
        };
    
        var method = CreateDelegate(path);
        var data = new Root { Level1 = new Level1 { Level2 = new Level2 { Name = "Test" } } };
        var result = method(data);
    }
