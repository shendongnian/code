    public void Map<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        var genericInterfaces = typeof(TProperty).GetInterfaces().Where(i => i.IsGenericType);
        var iEnumerables = genericInterfaces.Where(i => i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>))).ToList();
        if (iEnumerables.Count > 1)
            throw new InvalidOperationException("Ambiguous IEnumerable<>");
        var iEnumerable = iEnumerables.FirstOrDefault();
        if (iEnumerable == null)
        {
            Console.WriteLine("1");
        }
        else
        {
            //ok, we know we have an IEnumerable of something. Let the runtime figure it out.
            Expression<Func<T, IEnumerable<dynamic>>> newExpression = e => expression.Compile()(e) as IEnumerable<dynamic>;
            Map(newExpression);
        }
    }
    public void Map<TProperty>(Expression<Func<T, IEnumerable<TProperty>>> expression)
    {
        Console.WriteLine("2");
    }
