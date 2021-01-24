    public class WhereFinder<T> : MongoDB.Driver.Linq.ExpressionVisitor
        {
          private bool _processingWhere = false;
          private bool _processingLambda = false;
          public ParameterExpression _parameterExpression { get; set; }
    
          public WhereFinder(Expression expression)
          {
            Visit(expression);
          }
    
          public Expression<Func<T, bool>> TheWhereExpression { get; set; }
          public bool FoundWhere
          {
            get { return TheWhereExpression != null; }
          }
    
          protected override Expression Visit(Expression exp)
          {
            return base.Visit(exp);
          }
          protected override Expression VisitBinary(BinaryExpression node)
          {
            var result = base.VisitBinary(node);
            if (_processingWhere)
            {
              TheWhereExpression = (Expression<Func<T, bool>>) Expression.Lambda(node, _parameterExpression);
            }
            return result;
          }
          protected override Expression VisitParameter(ParameterExpression node)
          {
            if (_processingWhere || _processingLambda || _parameterExpression == null)
              _parameterExpression = node;
            return base.VisitParameter(node);
          }
          protected override Expression VisitMethodCall(MethodCallExpression expression)
          {
            string methodName = expression.Method.Name;
    
            if (methodName == "Where")
              _processingWhere = true;
            if (expression?.Arguments != null)
              foreach (var arg in expression.Arguments)
                Visit(arg);
            _processingWhere = false;
    
            return expression;
    	}
    	protected override Expression VisitLambda(LambdaExpression exp)
    	{
    		if (_processingWhere)
    		{
    			if (_parameterExpression == null)
    				_parameterExpression = exp.Parameters?.FirstOrDefault();
    
    			TheWhereExpression = (Expression<Func<T, bool>>)Expression.Lambda(exp.Body, _parameterExpression);
    		}
    		return exp;
    	}
    
    }
