    public static IQueryable<Foo> GetFooQuery(IQueryable<Foo> query, MyContext context)
    {
        var barPredicateBuilder = PredicateBuilder.True<Bar>();
        barPredicateBuilder = barPredicateBuilder.And(b => b.IsSomething);
        var fooPredicateBuilder = PredicateBuilder.True<Foo>();
        fooPredicateBuilder = fooPredicateBuilder.And(f => f.IsGood);
        fooPredicateBuilder = fooPredicateBuilder.And(f => context.Bars
                                                                  .Where(barPredicateBuilder).AsExpandable() // B
                                                                  .Where(b => b.ReferenceId == f.Id) // A
                                                                  .Any());
        query = query.Where(fooPredicateBuilder).AsExpandable();
        return query;
    }
