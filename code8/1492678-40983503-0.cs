    static void Do<TEntity, TProp>(TEntity entity, Expression<Func<TEntity, TProp>> property)
    {
        var member = property.Body as MemberExpression;
        if (member != null)
        {
            var propertyName = member.Member.Name;
            var propertyValue = property.Compile()(entity);
            //Do something.
        }
    }
