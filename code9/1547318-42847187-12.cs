    delegate T ThingCreator<T>() where T : IThing;
    delegate IThing ThingCreator();    
    public class Program
    {
    	static void Test(ThingCreator tc)
    	{
    	  Console.WriteLine(tc.Method.ReturnType);
    	}
    	static ThingCreator DoIt<T>(ThingCreator<T> tc) where T : class, IThing
    	{ 
          return tc.Invoke; 
        }
    	public static void Main()
    	{
          Test(DoIt(() => new Foo()));
    	}
    }
