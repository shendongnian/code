    public abstract class A {
       public string MyMethod() {
          return "a";
       }
    }
    
    public class B<T> where T : A {
       public void AnotherMethod() {
          var S1 = base.MyMethod();    // Line 1
          var S2 = T.MyMethod();       // Line 2
       }
    }
