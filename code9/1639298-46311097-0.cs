    using System;
    
    public class TestClass
    {
        
        Action testDelegate;
    
        public TestClass()
        {
            testDelegate = new Action(MyMethod);
        }
    
    	public static void Testit()
    	{
    		TestClass ts = new TestClass();
    		ts.testDelegate();
    	}
    
        private void MyMethod()
        {
            Console.WriteLine("Foobar");
        }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		TestClass.Testit();
    	}
    }
