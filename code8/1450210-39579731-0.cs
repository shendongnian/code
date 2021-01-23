    public class Foo
    {
    	public Bar Bar { get; set;}
    }
    
    public class Bar
    {
    	public Baz Baz { get; set;}
    }
    
    public class Baz
    {
    	public string One { get; set; } = string.Empty;
    	public string Two { get; set; } = string.Empty;
    	public bool BothPopulated() => !(string.IsNullOrWhiteSpace(One) || string.IsNullOrWhiteSpace(Two));
    }
    
    public class FooFactory
    {
    	public static Foo Create() => new Foo { Bar = new Bar { Baz = new Baz { One = "Hello", Two = "World" } } };
    }
    
