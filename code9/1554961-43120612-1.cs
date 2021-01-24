    var models = new FooDupeCheckModel[]
    {
        new FooDupeCheckModel() { Bar = 1, Bat = 2 },
        new FooDupeCheckModel() { Bar = 1, Bat = 3 }
    };
    var comparison = getComparison(models);
    IQueryable<Foo> foos = new Foo[]
    {
        new Foo() { Bar = 1, Bat = 1 },
        new Foo() { Bar = 1, Bat = 2 },
        new Foo() { Bar = 1, Bat = 3 },
        new Foo() { Bar = 1, Bat = 4 }
    }.AsQueryable();
    var results = foos.Where(comparison).ToArray();
    ...
    private static Expression<Func<Foo, bool>> getComparison(IEnumerable<FooDupeCheckModel> models)
    {
        ParameterExpression pe = Expression.Parameter(typeof(Foo), "f");
        var ands = models.Select(m =>
        {
            // Compare Bars
            Expression pBarId = Expression.Property(pe, "Bar");
            Expression vBarId = Expression.Constant(m.Bar);
            Expression bar = Expression.Equal(pBarId, vBarId);
            // Compare Bats
            Expression pBatId = Expression.Property(pe, "Bat");
            Expression vBatId = Expression.Constant(m.Bat);
            Expression bat = Expression.Equal(pBatId, vBatId);
            Expression and = Expression.And(bar, bat);
            return and;
        }).ToArray();
        if (ands.Length == 0)
        {
            return Expression.Lambda<Func<Foo, bool>>(Expression.Constant(true), pe);
        }
        else
        {
            Expression ors = ands.First();
            foreach (Expression and in ands.Skip(1))
            {
                ors = Expression.OrElse(ors, and);
            }
            return Expression.Lambda<Func<Foo, bool>>(ors, pe);
        }
    }
