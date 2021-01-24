    public class A {
      B _b;
      public A(B b) {
        _b = b;
        Console.WriteLine("Creating A");
      }
    }
    public class B {
      A _a;
      public B(A a) {
        _a = a;
        Console.WriteLine("Creating B");
      }
    }
    public class C {
      A _a;
      B _b;
      public C (A a, B b) {
        _a = a;
        _b = b;
        Console.WriteLine("Creating C");
      }
    }
