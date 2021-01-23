    class A {
      private B _b;
      public A(B b) {
        _b = b;
      }
    }
    class B {
      private A _a;
      public B(A a) {
        _a = a;
      }
    }
