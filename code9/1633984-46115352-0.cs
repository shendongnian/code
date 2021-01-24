    void Main()
    {
    	var foos = new List<Foo>()
    	{
    		new Foo() { Bar = 1 }
    	};
    	
    	foreach (var f in foos.Do(f => f.Bar = 42))
    	{
    		Console.WriteLine(f.Bar);
    	}
    }
    
    public class Foo
    {
    	public int Bar;
    }
