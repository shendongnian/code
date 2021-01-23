    public class BaseClass {
         // Call child class constructor
         public BaseClass() : A() { }
     }
     public class A : BaseClass {
          public A() { ... }
     }
     // How should BaseClass handle this? There is no constructor named "A."
     public class B : BaseClass {
            public B() { ... }
     }
