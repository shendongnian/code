    internal class ExpressionTreeModifier<T> : ExpressionVisitor
    {
        private IQueryable<T> _queryableData;
        internal ExpressionTreeModifier(IQueryable<T> queryableData)
        {
            _queryableData = queryableData;
        }
        protected override Expression VisitConstant(ConstantExpression c)
        {
            // Here the magic happens: the expression types are all NHibernateQueryableProxy,
            // so we replace them by the correct ones
            if (c.Type == typeof(NHibernateQueryableProxy<T>))
                return Expression.Constant(_queryableData);
            else
                return c;
        }
    }
