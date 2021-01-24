    public class Search
    {
    	private Expression<Func<CustomerFilter, bool>> customerfilter;
    
    	public Expression<Func<CustomerFilter, bool>> CustomerFilter
    	{
    		set { customerfilter = value; }
    	}
    	
    	public object GetValue(CustomerFilter filter)
    	{
    		var property = (customerfilter.Body as BinaryExpression).Left;
    		var lambda =Expression.Lambda(property, customerfilter.Parameters.First());
    		return lambda.Compile().DynamicInvoke(filter);
    	}
    }
