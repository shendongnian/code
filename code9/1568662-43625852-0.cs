    // Locates a method on this class that has the SpecialMethod attribute of the given name
    private Func<int, string> FindMethodByAccessor(string accessor)
    {
        // Find all methods containing the attribute
        var desiredMethod = this.GetType().GetMethods()
                  .Where(x => x.GetCustomAttributes(typeof(SpecialMethod), false).Length > 0)
                  .Where(y => (y.GetCustomAttributes(typeof(SpecialMethod), false).First() as SpecialMethod).Accessor == accessor)
                  .FirstOrDefault();
        if (desiredMethod == null) return null;
        // This parameter is the first parameter passed into the method. In this case it is an int.    
        ParameterExpression x = Expression.Parameter(typeof(int));
        // This parameter refers to the instance of the class. 
        ConstantExpression instance = Expression.Constant(this);
        // This generates a piece of code and returns it in a Func object. We effectively are simply calling the method.
        return Expression.Lambda<Func<int, string>>(
            Expression.Call(instance, desiredMethod, new Expression[] { x }), x).Compile();
    }
