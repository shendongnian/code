    public static IEnumerable<T> IgnoreIfNull<T, TProp>(this IEnumerable<T> sequence, Expression<Func<T, TProp>> expression)
        {
            var predicate = BuildNotNullPredicate(expression);
            return sequence.Where(predicate);
        }
        private static Func<T, bool> BuildNotNullPredicate<T, TProp>(Expression<Func<T, TProp>> expression)
        {
            var root = expression.Body;
            if (root.NodeType == ExpressionType.Parameter)
            {
                return t => t != null;
            }
            var pAccessMembers = new List<Expression>();
            while (root.NodeType == ExpressionType.MemberAccess)
            {
                var mExpression = root as MemberExpression;
                pAccessMembers.Add(mExpression);
                root = mExpression.Expression;
            }
            pAccessMembers.Reverse();
            var body = pAccessMembers
                .Aggregate(
                (Expression)Expression.Constant(true),
                (f, s) =>
                {
                    if (s.Type.IsValueType)
                    {
                        return f;
                    }
                    return Expression.AndAlso(
                            left: f,
                            right: Expression.NotEqual(s, Expression.Constant(null))
                        );
                });
            var lambda = Expression.Lambda<Func<T, bool>>(body, expression.Parameters[0]);
            var func = lambda.Compile();
            return func;
        }
