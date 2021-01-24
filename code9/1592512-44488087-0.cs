       public class Event
        {
        	public string A {get;set;}
        	public string B {get;set;}
        	public string C {get;set;}
        }
        
        
        
            				
    public static class Extensions
    {
        public static Expression<Func<T, Boolean>> AndAlso<T>(this Expression<Func<T, Boolean>> left, Expression<Func<T, Boolean>> right)
        	{
        		Expression<Func<T, Boolean>> combined = Expression.Lambda<Func<T, Boolean>>(
        			Expression.AndAlso(
        				left.Body,
        				new ExpressionParameterReplacer(right.Parameters, left.Parameters).Visit(right.Body)
        				), left.Parameters);
        				
          				 return combined;
        	}
        }
            	
			
        public class ExpressionParameterReplacer : ExpressionVisitor
        {
            private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; set; }
        
            public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
            {
                ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
        
                for(int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                { ParameterReplacements.Add(fromParameters[i], toParameters[i]); }
            }
        
            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterExpression replacement;
        
                if(ParameterReplacements.TryGetValue(node, out replacement))
                { node = replacement; }
        
                return base.VisitParameter(node);
            }           
        }
    
