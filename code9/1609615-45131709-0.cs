    private static Expression<Func<TInNew, TOut>> UpdateExpressionRoot<TOut, TInOld, TInNew>(Expression<Func<TInNew, TInOld>> newRoot, Expression<Func<TInOld, TOut>> memberAccess)
    {
        Func<MemberExpression, MemberExpression> updateDeepestExpression = null;
        updateDeepestExpression = e =>
        {
            if (e.Expression is MemberExpression)
            {
                var updatedChild = updateDeepestExpression((MemberExpression)e.Expression);
                return e.Update(updatedChild);
            }
            if (e.Expression is ParameterExpression)
                return e.Update(newRoot.Body);
            throw new ArgumentException("Member access expression must be composed of nested member access expressions only.", nameof(memberAccess));
        };
        return Expression.Lambda<Func<TInNew, TOut>>(updateDeepestExpression(memberAccess.Body as MemberExpression), newRoot.Parameters);
    }
