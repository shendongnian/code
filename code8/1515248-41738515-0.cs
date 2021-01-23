        public EntityTypeConfiguration<TEntityType> IgnoreAndReport<TEntityType, TProperty>(Expression<Func<TEntityType, TProperty>> propertyExpression)
        {
            this.Ignore(propertyExpression);
            LambdaExpression lambda = propertyExpression as LambdaExpression;
            MemberExpression memberExpr = null;
            if (lambda.Body.NodeType == ExpressionType.Convert)
                memberExpr = ((UnaryExpression) lambda.Body).Operand as MemberExpression;
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
                memberExpr = lambda.Body as MemberExpression;
            EntityMapData.IgnoredProperties.Add(new Tuple<Type, string>(typeof(TEntityType), memberExpr.Member.Name));
        }
