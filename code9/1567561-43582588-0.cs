    class C1{
         public C2 Obj {get;set;}
    }
    
    class C2{}
    
    public class Program
    {
    	public static void Main()
    	{
    		C1 c1 = new C1();
    		C2 prop1 = c1.Obj;
    		c1.Obj = new C2();
    	}
    }
