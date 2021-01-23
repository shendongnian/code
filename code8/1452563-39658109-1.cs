    internal class KendoExpressionModifier : ExpressionVisitor
    {
    	public Expression Modify(Expression expression)
    	{
    		return Visit(expression);
    	}
    
    	protected override Expression VisitConditional(ConditionalExpression node)
    	{
    		//converting result of conditional expression to string
    		return Expression.Call(node.IfTrue, typeof(object).GetMethod("ToString"));
    	}
    
    	protected override Expression VisitBinary(BinaryExpression node)
    	{
    		//replacing '==' operator with '.Contains'
    		if (node.NodeType == ExpressionType.Equal)
    		{
    			var left = this.Visit(node.Left);
    			var right = this.Visit(node.Right);
    
    			return Expression.Call(left, typeof(string).GetMethod("Contains"), right);
    		}
    		//replacing expression 'a.ToString() ?? ""' with 'a != null ? a.ToString() : ""'
    		else if (node.NodeType == ExpressionType.Coalesce)
    		{
    			var left = this.Visit(node.Left) as MethodCallExpression;
    
    			return Expression.Condition(
    				Expression.MakeBinary(
                        ExpressionType.NotEqual, 
                        left.Object, 
                        Expression.Constant(null)), 
    				left, 
    				Expression.Constant(string.Empty));
    		}
    
    		return base.VisitBinary(node);
    	}
    
    	protected override Expression VisitConstant(ConstantExpression node)
    	{
    		//replacing constant numeric value with its string representation
    		if (node.Value.GetType() != typeof(string))
    		{
    			return Expression.Call(node, typeof(object).GetMethod("ToString"));
    		}
    
    		return base.VisitConstant(node);
    	}
    }
