    public class A {
      D _d;
      public A(D d) {
        _d = d;
        Console.WriteLine("Creating A");
      }
    }
    public class B {
      A _a;
      D _d;
      public B(A a, D d) {
        _a = a;
        _d = d;
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
    public class D {
      public D () {
        Console.WriteLine("Creating D");
      }
    }
