    public static class Helper
    {
        public static IQueryable<TResult> SelectWithReplace<T, TKey, TResult>(this  IQueryable<IGrouping<TKey, T>> queryable, Expression<Func<IGrouping<TKey, T>, Func<T, int?>, TResult>> select, Expression<Func<T, int?>> replaceWith)
        {
            var paramToReplace = select.Parameters[1];
            var newBody = new ReplaceVisitor(paramToReplace, replaceWith).Visit(select.Body);
            var newSelect = Expression.Lambda<Func<IGrouping<TKey, T>, TResult>>(newBody, new[] { select.Parameters.First() });
            return queryable.Select(newSelect);
        }
        public class ReplaceVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression toReplace;
            private readonly Expression replaceWith;
            public ReplaceVisitor(ParameterExpression toReplace, Expression replaceWith)
            {
                this.toReplace = toReplace;
                this.replaceWith = replaceWith;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if(node == toReplace)
                {
                    return this.replaceWith;
                }
                return base.VisitParameter(node);
            }
        }
    }
