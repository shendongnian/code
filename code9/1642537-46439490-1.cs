    public class ExpressionAnalizer<TModel> where TModel : class
        {
            public string BuildExpression(Expression<Func<TModel, bool>> expression)
            {
                if (expression?.Body is MethodCallExpression)
                    return BuildMethodCallExpression(expression);
    
                throw new ArgumentException($"The expression '{expression?.Body}' is unsupported");
            }
    
            public string BuildMethodCallExpression(Expression<Func<TModel, bool>> expression)
            {
                var body = expression.Body as MethodCallExpression;
                
                //Get Method Name
                string method = body.Method.Name;
    
                //Get List of String Values 
                var methodExpression = ResolveMemberExpression(body.Object);
                var listValues = ReadValue(methodExpression);
                var vString = string.Format("'{0}'", string.Join("' , '", (listValues as List<string>)));
    
                //Read Propery Name
                var argExpression = ResolveMemberExpression(body.Arguments[0]);
                var propertyName = argExpression.Member.Name;
    
                return $"{propertyName} {method} ({vString})";  
    
            }
    
            public MemberExpression ResolveMemberExpression(Expression expression)
            {
    
                if (expression is MemberExpression) return (MemberExpression)expression;
                if (expression is UnaryExpression) return (MemberExpression)((UnaryExpression)expression).Operand;
                
                throw new NotSupportedException(expression.ToString());
            }
    
            private object ReadValue(MemberExpression expression)
            {
                if (expression.Expression is ConstantExpression)
                {
                    return (((ConstantExpression)expression.Expression).Value)
                            .GetType()
                            .GetField(expression.Member.Name)
                            .GetValue(((ConstantExpression)expression.Expression).Value);
                }
                if (expression.Expression is MemberExpression) return ReadValue((MemberExpression)expression.Expression);
                
                throw new NotSupportedException(expression.ToString());
            }
    
        }
