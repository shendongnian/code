    void Main()
    {
    	Expression<Func<Foo, decimal>> exp = q => q.Bar;
    	var p = exp.GetProperty();
    
    	var f = new Foo();
    	p.SetValue(f, 42m);
    	Console.WriteLine(f.Bar);
    }
    
    public class Foo
    {
    	public decimal Bar { get; set; }
    }
