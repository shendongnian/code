    static Expression<Func<T, bool>> GetExprContains<T>(string name, string[] value)
    {
      ParameterExpression param = Expression.Parameter(typeof(T), "x");
      Expression prop = Expression.Property(param, name); // this is the property name, e.g. .Name
      Expression<Func<string[]>> valueLambda = () => value; // This is the value for .Contains() expression.
      var mi =
        typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
          .FirstOrDefault(x => x.Name == "Contains" && x.GetParameters().Count() == 2)
          .MakeGenericMethod(typeof(string)); // Need methodinfo for .Contains(), might want to keep static somewhere
      var lookupExpr = Expression.Call(null, mi, valueLambda.Body, prop);
      Expression<Func<T, bool>> expr = Expression.Lambda<Func<T, bool>>(lookupExpr, param);
      return expr;
    }
