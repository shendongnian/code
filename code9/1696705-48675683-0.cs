    void Main()
    {
    	B b = new B();
    	A a = b as A;
    	Console.WriteLine(a.GetType().Name); // Output B
    }
    
    public class A {}
    public class B : A {}
