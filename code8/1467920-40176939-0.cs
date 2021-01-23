    public interface IShape
    {
    	float Area { get; }
    	float circumference { get; }
    }
    public class Rectangle : IShape
    {
    	private float l, h;
    	public Rectangle( float length, float height ) { l = length; h = height; }
    	public float Area { get { return l * h; } }
    	public float circumference { get { return ( l + h ) * 2; } }
    }
    public class Circle : IShape
    {
    	private float r;
    	public Circle( float radius ) { r = radius; }
    	public float Area { get { return (float)Math.PI * r * r; } }
    	public float circumference { get { return (float)Math.PI * r * 2; } }
    }
    
    public class SomeClass
    {
    	IShape[] shapes = new IShape[] // Can store all shapes regardless of its type
    	{
    		new Rectangle( 10f, 20f ),
    		new Rectangle( 15f, 20f ),
    		new Rectangle( 11.6f, .8f ),
    
    		new Circle( 11f ),
    		new Circle( 4.7f )
    	};
    	public void PrintAreas()
    	{
    		foreach ( var sh in shapes )
    			Console.WriteLine( sh.Area ); // prints area of shape regardless of its type
    	}
    
    	public void PrintCircumference(IShape shape )
    	{
    		Console.WriteLine( shape.circumference ); // again its not important what is your shape, you cant use this function to print its cicumference
    	}
    }
