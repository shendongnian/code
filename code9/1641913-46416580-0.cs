    void Main()
    {
    	converters.Add(typeof(KittyA), ToPointConverter<KittyA>.Create(kitty => kitty.Location));
    	converters.Add(typeof(KittyB), ToPointConverter<KittyB>.Create(kitty => new Point { X = kitty.X, Y = kitty.Y }));
    	converters.Add(typeof(KittyC), ToPointConverter<KittyC>.Create(kitty => kitty.MyLocation));
    
    	var kitty1 = new KittyA { Location = new Point { X = 1, Y = 1 } };
    	var kitty2 = new KittyB { X = 3, Y = 2 };
    	var kitty3 = new KittyC { MyLocation = new Point { X = 2, Y = 10 } };
    
    	GetDistance(kitty1, kitty2).Dump();
    	GetDistance(kitty1, kitty3).Dump();
    
    	GetDistance(kitty2, kitty1).Dump();
    	GetDistance(kitty2, kitty3).Dump();
    
    	GetDistance(kitty3, kitty1).Dump();
    	GetDistance(kitty3, kitty2).Dump();
    }
    private Dictionary<Type, IToPointConverter> converters = new Dictionary<Type, IToPointConverter>();
    
    private double GetDistance(object obj1, object obj2)
    {
    	var point1 = GetConvrterFor(obj1).Convert(obj1);
    	var point2 = GetConvrterFor(obj2).Convert(obj2);
    
    	return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
    }
    
    private IToPointConverter GetConvrterFor(object obj) => converters[obj.GetType()];
    
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
    
    public interface IToPointConverter
    {
    	Point Convert(object obj);
    }
    
    public struct Point
    {
    	public int X;
    	public int Y;
    }
    
    
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
