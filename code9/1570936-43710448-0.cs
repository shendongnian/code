    public static PropertyInfo GetProperty<TObject, TProperty>(
      this Expression<Func<TObject, TProperty>> selectorExpression)
        => selectorExpression.Body is MemberExpression memberExpression
          && memberExpression.Member is PropertyInfo propertyInfo
            ? propertyInfo
            : throw new InvalidCastException();
