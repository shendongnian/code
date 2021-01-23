    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(new C().X);
    	}
    	
    }
    public class A
    {
        public class B
        { 
            public int X;
            public B(){
                X = 5;
            }
        }
    }
    
    public class C{
      public int X {get;set;}
      public C(){
        var objB = new A.B();
        X = objB.X;   
      }
    }
