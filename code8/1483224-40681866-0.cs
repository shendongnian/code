    public bool HasPermission(int groupId, Expression<Func<T>> propertySelector)
    {
        if (propertyExpresssion == null)
        {
            throw new ArgumentNullException("propertyExpresssion");
        }
        var memberExpression = propertyExpresssion.Body as MemberExpression;
        if (memberExpression == null)
        {
            throw new ArgumentException("The expression is not a member access expression.", "propertyExpresssion");
        }
        var property = memberExpression.Member as PropertyInfo;
        if (property == null)
        {
            throw new ArgumentException("The member access expression does not access a property.", "propertyExpresssion");
        }
        var getMethod = property.GetGetMethod(true);
        if (getMethod.IsStatic)
        {
            throw new ArgumentException("The referenced property is a static property.", "propertyExpresssion");
        }
        var name = memberExpression.Member.Name;
    }
