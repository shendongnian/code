    void Main()
    {
    	// Arrange
    	var foo = new Mock<Foo> { CallBase = true };
    	var bar = new Mock<IBar>();
    	bar.Setup(b => b.Value).Returns(2);
    	// setup an IBar mock
    	foo.Setup(f => f.CreateBar()).Returns(bar.Object);
    
    	// Act
    	var results = foo.Object.DoStuff();
    	
    	results.Dump(); // Prints "2"
    }
    
    public class Foo
    {
    	public int DoStuff()
    	{
    		var bar = CreateBar();
    		return bar.Value;
    	}
    
    	public virtual IBar CreateBar()
    	{
    		return new RealBar();
    	}
    }
    
    public interface IBar 
    {
    	int Value { get;}
    }
    
    public class RealBar : IBar
    {
    	public int Value
    	{
    		get { return 1; }
    	}
    }
