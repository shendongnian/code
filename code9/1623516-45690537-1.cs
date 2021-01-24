    public IQueryable<FooBar> GetFooQuery( .. Many properties used to the query .. , decimal multiplier)
    {
        return Context.Set<Foo>()
            .Where(querying with the parameters)
            .Select(foo => new FooBar
            {
                Foo = foo,
                Bar = foo.Bar * multiplier
            });
    }
