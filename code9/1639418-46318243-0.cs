    void Main()
    {
    	var types = new[] { typeof(ExampleClass), typeof(ExampleClass[]) };
    	var objects = new List<object>();
    
    	foreach (var type in types)
    	{
    		Debug.WriteLine($"{type}");
    		objects.Add(type.IsArray
    					? Activator.CreateInstance(type, 1)
    					: Activator.CreateInstance(type));
    	}
    }
    
    // Define other methods and classes here
    
    public class ExampleClass
    {
    	public int X;
    	public int Y;
    }
