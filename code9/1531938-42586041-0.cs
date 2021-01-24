    public static UnaryExpression WrapInPropertyAccess(this ConstantExpression constant) {
        Tuple<object> container = new Tuple<object>(constant.Value);
        Expression containerExpression = Expression.Constant(container, typeof(Tuple<object>));
        MemberExpression propAccess = Expression.Property(containerExpression, "Item1");
        UnaryExpression result = Expression.Convert(propAccess, constant.Type); // Cast back the object to the value type
        return result;
    }
    private Expression<TEntity, bool> FieldEqualsValue(string value) {
        var comparison = Expression.Equal(fieldWhichMustEqualValue.Body, Expression.Constant(value).WrapInPropertyAccess());
        return Expression.Lambda<Func<TEntity, bool>>(comparison, fieldWhichMustEqualValue.Parameters);
    }
    
    public override IQueryable<TEntity> Filter(IQueryable<TEntity> filteredEntityCollection, string value)
    {
        var condition = FieldEqualsValue(value);
        return filteredEntityCollection.Where(condition);
    }
