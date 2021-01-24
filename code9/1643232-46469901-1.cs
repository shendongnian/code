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
        //If you want to have the Area property available on sub-class instances, comment out the next line, and uncommment the one after it.
    	public static int Area { get; protected set; }
        //public int Area=> this.GetType().GetCustomAttribute<AreaAttribute>().Value;
    }
    
    [AreaAttribute(1)]
    abstract class Middle1 : Top<Middle1>
    {
    	static Middle1()
    	{
    		Area = 1;
    	}
    }
    sealed class M1Sub1 : Middle1 { }
    sealed class M1Sub2 : Middle1 { }
    sealed class M1Sub3 : Middle1 { }
    
    [AreaAttribute(2)]
    abstract class Middle2 : Top<Middle2>
    {
    	static Middle2()
    	{
    		Area = 2;
    	}
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
