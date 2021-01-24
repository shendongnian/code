     public void SetValue<T, TP>(T obj, Expression<Func<T, TP>> action, TP value) where T : class
     {
          var member = action.Body is UnaryExpression 
                     ? ((MemberExpression)((UnaryExpression)action.Body).Operand) 
                     : (action.Body is MethodCallExpression 
                         ? ((MemberExpression)((MethodCallExpression)action.Body).Object) 
                         : (MemberExpression)action.Body);
         var key = member?.Member.Name;
         typeof(T).GetProperty(key).SetValue(obj, value);
     }
