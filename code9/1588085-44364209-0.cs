    // Taken (with some cuts) from https://stackoverflow.com/a/32007349/613130
    // A simple expression visitor to replace some nodes of an expression 
    // with some other nodes. Can be used with anything, not only with
    // ParameterExpression
    public class SimpleExpressionReplacer : ExpressionVisitor
    {
        public readonly Dictionary<Expression, Expression> Replaces;
        public SimpleExpressionReplacer(Expression from, Expression to)
        {
            Replaces = new Dictionary<Expression, Expression> { { from, to } };
        }
        public override Expression Visit(Expression node)
        {
            Expression to;
            if (node != null && Replaces.TryGetValue(node, out to))
            {
                return base.Visit(to);
            }
            return base.Visit(node);
        }
    }
    public static Expression<Func<T, TProp2>> ExtendExpression<T, TProp1, TProp2>(Expression<Func<T, TProp1>> exp1, Expression<Func<TProp1, TProp2>> exp2)
    {
        Expression body3 = new SimpleExpressionReplacer(exp2.Parameters[0], exp1.Body).Visit(exp2.Body);
        Expression<Func<T, TProp2>> exp3 = Expression.Lambda<Func<T, TProp2>>(body3, exp1.Parameters);
        return exp3;
    }
