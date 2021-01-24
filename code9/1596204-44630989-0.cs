    public class Ext
    {
    	public static IEnumerable<T> MixObjectsByProperty<T, TProp, U>(
    		IEnumerable<T> source,
    		Expression<Func<T, TProp>> property,
    		IEnumerable<IEnumerable<U>> groupsToMix = null)
    		where T : class
    		where U : TProp
    	{
    		var prop = (PropertyInfo)(property.Body as MemberExpression)?.Member;
    		if (prop == null) throw new ArgumentException("Couldn't determine property");
    		
    		var accessor = property.Compile();
    		
    		var groups = 
    			from item in source
    			let value = (U)accessor(item)
    			group item by
    				groupsToMix.FirstOrDefault((ids => ids.Contains(value)))
    			into itemGroup
    			select itemGroup.ToArray();
    		return groups.SelectMany(x => x);
    	}
    }
