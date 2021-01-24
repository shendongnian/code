    protected static  Expression<Func<MyEntity, bool>> GetFilterPredicate(
        PagingParameters pagingParameters,
        Expression<Func<MyEntity, DateTime?>> terminationDate,
        Expression<Func<MyEntity, string>> entityID,
        Expression<Func<MyEntity, string>> name
    )
    {
        Expression<Func<MyEntity, bool>> validFilter = x => true;
        // We need to replace the parameter for all expressions with 
        // a common single parameter. I used the parameter for the default
        // filter but a new Parameter expression would have worked as well.
        // If you don't do this you will get an error (unbound parameter or something like that ) because the parameter  
        // used in the expressions (terminationDate, entityID) will be 
        // different then the parameter used for the new validFilter expression
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
    /// <summary>
    /// Simple Parameter Replacer, will replace the any parameter with the new
    /// parameter. You will need to refine this if your expressions have nested 
    /// lambda, in that you will need to only replace the top most lambda 
    /// parameter, but for simple expressions it will work fine.
    /// </summary>
    class ReplaceVisitor : ExpressionVisitor
    {
        public ParameterExpression NewParameter { get; set; }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this.NewParameter;
        }
    }
