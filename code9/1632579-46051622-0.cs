    public class MyClass 
    {
    	public void MyMethod() { }
    	
    	public static void MyStaticMethod() { }
    }
    
    MyClass.MyStaticMethod(); // Works
    MyClass.MyMethod(); // CS0120
    
    // You've got to do it like this
    
    MyClass mc = new MyClass();
    mc.MyMethod();
