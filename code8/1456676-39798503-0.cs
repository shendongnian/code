    using System;
			
    public class Program
    {
    	public static void Main()
    	{
            var c = new C();
            F(ref c.P);
    	}
        public static void F(ref int n) { }
        public class C
        {
            public int P { get; set; }
        }
    }
