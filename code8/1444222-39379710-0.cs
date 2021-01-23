    void Main()
    {
    	var key = typeof(ConnectionTypeOne).FullName;
    	Func<IElement, bool, bool, IEnumerable<IConnectionTable>> expr = 
    		_cache.ContainsKey(key) ? _cache[key]
    		: CreateConnectionExpression<ConnectionTypeOne>(key);
    		
    	expr(new Element(), true, true);
    }
    
    private static IDictionary<string, Func<IElement, bool, bool, IEnumerable<IConnectionTable>>> _cache = 
        new Dictionary<string, Func<IElement, bool, bool, IEnumerable<IConnectionTable>>>();
    
    private Func<IElement, bool, bool, IEnumerable<IConnectionTable>> CreateConnectionExpression<T>(string connectionType)
    	where T : IConnectionTable
    {
    	// Get the type element from the passed string.
    	Type elementType = Type.GetType(connectionType, true);
    
    	// Create the generic method using that type.
    	MethodInfo method = typeof(MyClass).GetMethod("GetConnections", new Type[] { typeof(IElement), typeof(bool), typeof(bool) });
    	MethodInfo generic = method.MakeGenericMethod(elementType);
    
    	var instance = Expression.Constant(new MyClass());
    	var c1 = Expression.Parameter(typeof(IElement));
    	var c2 = Expression.Parameter(typeof(bool));
    	var c3 = Expression.Parameter(typeof(bool));
    
    	var expr = Expression.Call(instance, generic, c1, c2, c3);
    	Func<IElement, bool, bool, IEnumerable<IConnectionTable>> compiledExpr =
    		(Func<IElement, bool, bool, IEnumerable<IConnectionTable>>)
    			Expression.Lambda<Func<IElement, bool, bool, IEnumerable<T>>>
                    (expr, c1, c2, c3).Compile();
    
    	_cache[connectionType] = compiledExpr;
    
    	return compiledExpr;
    }
    
    public class MyClass 
    {
    	public List<T> GetConnections<T>(IElement element, bool getChildren, bool getParents) 
            where T : IConnectionTable, new()
    	{
    		Console.WriteLine("we got called");
    		return new List<T>();
    	}
    }
    
    public interface IElement { }
    public interface IConnectionTable { }
    
    public class Element : IElement { }
    public class ConnectionTypeOne : IConnectionTable { }
  
