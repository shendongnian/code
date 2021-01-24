    using System;
    
    public class Thing
    {
        public int field1;
        public string field2;    
    }
    
    public delegate ref TOutput FuncRef<TInput, TOutput>(TInput input);
        
    public class Test
    {
    	public static void Main()
    	{
            Thing thing1 = new Thing { field1 = 0, field2 = "foo" };
            Thing thing2 = new Thing { field1 = -5, field2= "foo" };
            UpdateIfChanged(thing1, thing2, (Thing t) => ref t.field1);
            UpdateIfChanged(thing1, thing2, (Thing t) => ref t.field2);
    	}
        
        static void UpdateIfChanged<TInput, TOutput>(TInput c1, TInput c2, FuncRef<TInput, TOutput> getter)
        {
            if (!getter(c1).Equals(getter(c2)))
            {
                getter(c1) = getter(c2);
            }
        }
    }
