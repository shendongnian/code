    public static Func<T, Dictionary<string, object>> GetValuesFunc<T>()
    {
        Type objType = typeof(T);
        var dict = Expression.Variable(typeof(Dictionary<string, object>));
        var par = Expression.Parameter(typeof(T), "obj");
        var add = typeof(Dictionary<string, object>).GetMethod("Add", BindingFlags.Public | BindingFlags.Instance, null, new[] { typeof(string), typeof(object) }, null);
        var body = new List<Expression>();
        body.Add(Expression.Assign(dict, Expression.New(typeof(Dictionary<string, object>))));
        var properties = objType.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        for (int i = 0; i < properties.Length; i++)
        {
            // Skip write only or indexers
            if (!properties[i].CanRead || properties[i].IsSpecialName)
            {
                continue;
            }
            var key = Expression.Constant(properties[i].Name);
            var value = Expression.Property(par, properties[i]);
            // Boxing must be done manually... For reference type it isn't a problem casting to object
            var valueAsObject = Expression.Convert(value, typeof(object));
            body.Add(Expression.Call(dict, add, key, valueAsObject));
        }
        // Return value
        body.Add(dict);
        var block = Expression.Block(new[] { dict }, body);
        var lambda = Expression.Lambda<Func<T, Dictionary<string, object>>>(block, par);
        return lambda.Compile();
    }
