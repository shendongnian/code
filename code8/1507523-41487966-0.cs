    private void Main()
    {
	    var values = new List<IComparable>();
	
	    values.Add(10);
	    values.Add(5.55D);
	
	    foreach (var value in values) {
		    Console.WriteLine(value); // The value
		    var childClass = BuildChild(value);
		    Console.WriteLine(childClass.GetType().FullName); // The type
            // Using dynamic will work
		    ((dynamic)childClass).DoWork((dynamic)value);
	    }
    }
    private static object BuildChild(IComparable value)
    {
	    if (value == null)
		    throw new ArgumentNullException(nameof(value));
	
	    Type valueType = value.GetType();
	    Type childClassType = typeof(ChildClass<>).MakeGenericType(valueType);
	    return Activator.CreateInstance(childClassType);
    }
    // Define other methods and classes here
    public abstract class BaseClass<T> where T : IComparable
    {
    }
    public class ChildClass<T> : BaseClass<T> where T : IComparable
    {
	    public void DoWork(T value) {
		    Console.WriteLine(value.GetType().FullName);
	    }
    }
