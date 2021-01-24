    static bool IsValid(LambdaExpression expression)
    {
      // Expression is in the form of parameter => something
      // Body is the 'something' part
      var body = expression.Body;
      // MemberExpression are like p.Name, that's a valid body
      if (body is MemberExpression) 
         return true;
      // MethodCallExpression are like p.Select(...) or p.Where(...) or p.DoSomething(...)
      var methodCallExpression = body as MethodCallExpression;
      // If it's not a methodcall, it can't be a select, so it's invalid
      if (methodCallExpression == null)
          return false;
      // Method contains the actual MethodInfo
      var method = methodCallExpression.Method;
      // Select is a generic method, so if it's not generic, it can't be valid
      if (!method.IsGenericMethod)
          return false;
      // Get the actual, parameterless methoddefinition of Enumerable.Select
      // NOTE: This is ugly as hell, but AFAIK there's no better way 
      // just query for the method whose name is 'Select' and has two parameters where the second one has two generic arguments (that's the Func argument)
      var selectMethod = typeof(Enumerable).GetMethods()
                        .Single(m => m.Name == nameof(Enumerable.Select) && m.GetParameters()[1].ParameterType.GetGenericArguments().Count() == 2);
      // If the method in the methodinfo is not the Select definition, it's not valid
      if (method.GetGenericMethodDefinition() != selectMethod)
          return false;
      // Otherwise the methodcall is in the form of p.Select(p=>'something else')
      // innerExpr gets the p=>'something else' part
      var innerExpr = methodCallExpression.Arguments[1];
      // If the expression really is a lambda expression, then recursively check the p=>'something else' part
      if (innerExpr is LambdaExpression lambda)
      {
        return IsValid(lambda);
      }
      else
      {
        // Otherwise it's invalid
        // NOTE: this is just in case, I'm not even sure if you can achieve this with regular C# code at compilation time
        return false;
      }                
    }
