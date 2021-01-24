    void Main()
    {
    	var array = Assembly.GetExecutingAssembly().DefinedTypes
    		.Where(t => t.IsSealed &&
    			t.BaseType != typeof(object) &&
    			t.BaseType != typeof(Enum))
    		.OrderBy(t => t.Name)
    		.GroupBy(t => t.BaseType)
    		.OrderByDescending(a => a.Key.GetCustomAttribute<AreaAttribute>().Value);
    
    	array.Dump();
    }
    
    abstract class Top { }
    
    abstract class Top<T> : Top
    {
        //If you want to have the Area property available on sub-class instances, uncomment this line.
        //public int Area=> this.GetType().GetCustomAttribute<AreaAttribute>().Value;
    }
    
    [Area(1)]
    abstract class Middle1 : Top<Middle1>
    {
    }
    sealed class M1Sub1 : Middle1 { }
    sealed class M1Sub2 : Middle1 { }
    sealed class M1Sub3 : Middle1 { }
    
    [Area(2)]
    abstract class Middle2 : Top<Middle2>
    {
    }
    sealed class M2Sub1 : Middle2 { }
    sealed class M2Sub2 : Middle2 { }
    sealed class M2Sub3 : Middle2 { }
    
    [AttributeUsage(AttributeTargets.Class)]
    public class AreaAttribute : Attribute
    {
    	public AreaAttribute(int value)
    	{
    		Value = value;
    	}
    
    	public int Value { get; }
    }
