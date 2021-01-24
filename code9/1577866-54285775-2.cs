    public class Foo
    {
    	public bool? Example { get; set; }
    }
    
    public class FooDto
    {
    	public bool Example { get; set; }
    }
    
    public void Example()
    {
    	var foo = new Foo
    	{
    		Example = null
    	};
    
    	var fooDto = new FooDto
    	{
    		Example = true
    	};
    
    	fooDto.MapModelProperties(foo);
    }
