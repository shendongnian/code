    private Expression BuildTableTwoExpression(ParameterExpression t1)
    {
        var arrayEx = Expression.NewArrayInit(typeof(TableTwo), Expression.Invoke(TableOne.FirstTableTwoReference, t1));
               
        Expression<Func<TableTwo, TableTwoSelect>> selector = (t2 => new TableTwoSelect
        {
            TableTowId = (Guid?)t2.TableTwoId,
            // ... some more properties of t2
        });
    
        Expression<Func<IEnumerable<TableTwo>, TableTwoSelect>> selectEx =
            ((t1s) => Enumerable.Select(t1s, selector.Compile()).FirstOrDefault());
    
        return Expression.Invoke(selectEx, arrayEx);
    }
