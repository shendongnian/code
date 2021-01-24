    public static class IQueryableExtensions
    {
        public static IQueryable<T> RemoveWhere<T>(this IQueryable<T> expression)
        {
            var delExpr = Expression.Lambda<Func<IQueryable<T>>>(new WhereRemoveVisitor().Visit(expression.Expression)).Compile();
            return delExpr();
        }
    }
