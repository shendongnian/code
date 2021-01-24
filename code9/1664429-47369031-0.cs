    protected static  Expression<Func<MyEntity, bool>> GetFilterPredicate(
        PagingParameters pagingParameters,
        Expression<Func<MyEntity, DateTime?>> terminationDate,
        Expression<Func<MyEntity, string>> entityID,
        Expression<Func<MyEntity, string>> name
    )
    {
        Expression<Func<MyEntity, bool>> validFilter = x => true;
        var parameterReplacer = new ReplaceVisitor
        {
            NewParameter = validFilter.Parameters.First()
        };
    
        if (pagingParameters.Active == true)
        {
            validFilter = Expression.Lambda<Func<MyEntity, bool>>(
                Expression.GreaterThan
                (
                    parameterReplacer.Visit(terminationDate.Body),
                    Expression.Constant(DateTime.Now, typeof(DateTime?))
                ),
                parameterReplacer.NewParameter
            );
        }
    
        // existing filter && x.EntityId != "A"
        validFilter = Expression.Lambda<Func<MyEntity, bool>>(
                Expression.And(
                    validFilter.Body,
                    Expression.NotEqual
                    (
                        parameterReplacer.Visit(entityID.Body),
                        Expression.Constant("A")
                    )
                ),
                parameterReplacer.NewParameter
            );
    
        return validFilter;
    }
