    public abstract class A {
       public string MyMethod() {
          return "a";
       }
    }
    
    public class B<T> where T : A {
       public void AnotherMethod(T t) {
             t.MyMethod();
       }
    }
    
    public class C : A {
    
    }
    
    public class BClosed : B<C> {
       public void Foo(C c) {
          c.MyMethod();
          this.AnotherMethod(c);
       }
    }
    
