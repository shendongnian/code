    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    	}
    }
    
    public class A
    {
        public string Text { get; set; }
    }
    
    public class AReadOnly
    {
         public AReadOnly(A a)
         {
             A = a;
         }
    
         private A A { get; }
    
         public string Text => A.Text;
    }
    
    public class B
    {
    	public B()
    	{
    		A = new AReadOnly(_A);
    	}
    	
        private A _A { get; } = new A();
        public AReadOnly A { get; }
    }
