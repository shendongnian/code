    public class A
    {
        // B is associated with A
        public B B { get; set; }
    }
    
    public class B
    {
         public void DoStuff() 
         {
         }
    }
    A a = new A();
    a.B = new B();
    a.B.DoStuff();
