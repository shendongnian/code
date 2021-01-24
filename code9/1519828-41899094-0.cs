     class Program
        {
            class MyClass
            {
                public void MyMethod() { }
            }
    
            static void Main(string[] args)
            {
                // Set a breakpoint here to see that mc = null.
                // However, the compiler considers it "unassigned."
                // and generates a compiler error if you try to
                // use the variable.
                // try Console.WriteLine(mc);
                // it will return error CS0165: Use of unassigned local variable `mc'
                MyClass mc;
                
                // Now the variable can be used, but...
                mc = null;
    
                // ... a method call on a null object raises 
                // a run-time NullReferenceException.
                // Uncomment the following line to see for yourself.
                // mc.MyMethod();
    
                // Now mc has a value.
                mc = new MyClass();
    
                // You can call its method.
                mc.MyMethod();
    
                // Set mc to null again. The object it referenced
                // is no longer accessible and can now be garbage-collected.
                mc = null;
           }
