        protected Expression EvaluateSubtree(Expression subtree)
        {
            ArgumentUtility.CheckNotNull(nameof(subtree), subtree);
            var memberExpression = subtree as MemberExpression;
            if (memberExpression != null)
            {
                Expression constant;
                if (TryEvaluateMember(memberExpression, out constant)) return constant;
            }
            if (subtree.NodeType != ExpressionType.Constant)
                throw new NHibernateExpressionOptimizerException(subtree);
            ConstantExpression constantExpression = (ConstantExpression)subtree;
            IQueryable queryable = constantExpression.Value as IQueryable;
            if (queryable != null && queryable.Expression != constantExpression)
                return queryable.Expression;
            return constantExpression;
        }
        bool TryEvaluateMember(MemberExpression memberExpression, out Expression constant)
        {
            constant = null;
            ConstantExpression c = memberExpression.Expression == null ? Expression.Constant(null) : EvaluateSubtree(memberExpression.Expression) as ConstantExpression;
            if (c == null) return false;
            var fieldInfo = memberExpression.Member as FieldInfo;
            if (fieldInfo != null)
            {
                constant = Expression.Constant(ReflectorReadFieldDelegate(fieldInfo, c.Value));
                return true;
            }
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo != null)
            {
                constant = Expression.Constant(ReflectorReadPropertyDelegate(propertyInfo, c.Value));
                return true;
            }
            return false;
        }
