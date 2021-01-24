    // The NestedGroupBy<> extension method
    public static class LinqExtensions
    {
    	public static IEnumerable<TTarget> NestedGroupBy<TSource, TTarget, TKey>(this IEnumerable<TSource> source, Func<TKey, IEnumerable<TTarget>, TTarget> factory, params Func<TSource, TKey>[] keySelectors)
    	{
    		return source.NestedGroupBy(factory, keySelectors, 0);
    	}
    
    	private static IEnumerable<TTarget> NestedGroupBy<TSource, TTarget, TKey>(this IEnumerable<TSource> source, Func<TKey, IEnumerable<TTarget>, TTarget> factory, Func<TSource, TKey>[] keySelectors, int selectorIndex)
    	{
            // reached the end, just return an empty list
    		if(selectorIndex >= keySelectors.Length)
    		{
    			return new List<TTarget>();
    		}
            // do the GroupBy using the function at index selectorIndex in our list to find the key (level name)
            // then call the factory to construct the target SomeObject, passing it the key and the recursive call to NestedGroupBy<>
            return source.GroupBy(keySelectors[selectorIndex])
            	.Select(f => factory(
            		f.Key,
            		f.NestedGroupBy(factory, keySelectors, selectorIndex + 1)
            	)
            );
    	}
    }
    // source object - assuming your result variable is List<LevelObject>
    public class LevelObject
    {
    	public string level1 {get;set;}
    	public string level2 {get;set;}
    	public string level3 {get;set;}
    
    	public LevelObject(string level1, string level2, string level3)
    	{
    		this.level1 = level1;
    		this.level2 = level2;
    		this.level3 = level3;
    	}
    }
    
    // target object - what we will end up with in our final list
    // the constructor is optional - it just makes the NestedGroupBy<> call cleaner.
    public class SomeObject
    {
    	public string name {get; set;}
    	public IEnumerable<SomeObject> children {get; set;}
    	
    	public SomeObject(string name, IEnumerable<SomeObject> children)
    	{
    		this.name = name;
    		this.children = children;
    	}
    }
    
    // Sample code to use it. The JToken/JsonConvert call at the end just pretty prints the result on screen.
    public static void Main()
   	{
        List<LevelObject> result = new List<LevelObject>()
        {
            new LevelObject("L1a1", "L2a1", "L3a1"),
        	new LevelObject("L1a1", "L2a2", "L3a1"),
        	new LevelObject("L1a1", "L2a1", "L3a2"),
        	new LevelObject("L1b1", "L2b1", "L3b1"),
        	new LevelObject("L1c1", "L2c1", "L3c1")
        };
        		
        /* old way - produces same result
        		var groupings = result.GroupBy(f => f.level1)
                      .Select(l1 => new SomeObject {
                          name = l1.Key,
                          children = l1.GroupBy(l2 => l2.level2)
                            .Select(l2 => new SomeObject{
                                name = l2.Key,
                                children = l2.GroupBy(l3 => l3.level3)
                                    .Select(l3 => new SomeObject{
                                        name = l3.Key,
                                        children = new List<SomeObject>()
        							})})}).ToList();
        */
        		
        var groupings = result.NestedGroupBy<LevelObject, SomeObject, string>(
            (key, children) => new SomeObject(key, children),
        	l => l.level1, l => l.level2, l => l.level3
        ).ToList();
        		
        Console.WriteLine(groupings.GetType());
        		
        Console.WriteLine(JToken.Parse(JsonConvert.SerializeObject(groupings)));
   	}
