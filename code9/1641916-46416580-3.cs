    void Main()
    {
        //Define conversion functions for anything that can be converted.
    	converters.Add(typeof(KittyA), ToPointConverter<KittyA>.Create(kitty => kitty.Location));
    	converters.Add(typeof(KittyB), ToPointConverter<KittyB>.Create(kitty => new Point { X = kitty.X, Y = kitty.Y }));
    	converters.Add(typeof(KittyC), ToPointConverter<KittyC>.Create(kitty => kitty.MyLocation));
    
        //Declare some kitties
    	var kitty1 = new KittyA { Location = new Point { X = 1, Y = 1 } };
    	var kitty2 = new KittyB { X = 3, Y = 2 };
    	var kitty3 = new KittyC { MyLocation = new Point { X = 2, Y = 10 } };
    
        //Calculate the distances
    	GetDistance(kitty1, kitty2).Dump();
    	GetDistance(kitty1, kitty3).Dump();
    
    	GetDistance(kitty2, kitty1).Dump();
    	GetDistance(kitty2, kitty3).Dump();
    
    	GetDistance(kitty3, kitty1).Dump();
    	GetDistance(kitty3, kitty2).Dump();
    }
    private Dictionary<Type, IToPointConverter> converters = new Dictionary<Type, IToPointConverter>();
    
    //A helper function that does the converts the passed objects in to Points, and calculates the distance between them.
    private double GetDistance(object obj1, object obj2)
    {
    	var point1 = GetConvrterFor(obj1).Convert(obj1);
    	var point2 = GetConvrterFor(obj2).Convert(obj2);
    
    	return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
    }
    
    //Another helper that gets the IToPointConverter for the object instance passed in.
    private IToPointConverter GetConvrterFor(object obj) => converters[obj.GetType()];
    
    //This generic class stores a lambda expression that converters from T to a Point
    public class ToPointConverter<T> : IToPointConverter
    {
    	public static ToPointConverter<T> Create(Func<T, Point> conversion)
    	{
    		return new ToPointConverter<T>(conversion);
    	}
    
    	private ToPointConverter(Func<T, Point> conversion)
    	{
    		_conversion = conversion;
    	}
    
    	private Func<T, Point> _conversion;
    
    	public Point Convert(T obj) => _conversion(obj);
    
    	Point IToPointConverter.Convert(object obj) => Convert((T)obj);
    }
    
    //The non-generic interface for the converter (so different closed generic types can be stored in the same dictionary, and have their Convert method called.)
    public interface IToPointConverter
    {
    	Point Convert(object obj);
    }
    
    //Just a standard structure to hold a location.  You would use whatever native location class your framework has.
    public struct Point
    {
    	public int X;
    	public int Y;
    }
    
    
    //Some example kitty classes
    public class KittyA
    {
    	public Point Location { get; set; }
    }
    
    public class KittyB
    {
    	public int X { get; set; }
    	public int Y { get; set; }
    }
    
    public class KittyC
    {
    	public Point MyLocation { get; set; }
    }
