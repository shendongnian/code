    class A {
      private C _c;
      public A(C c) {
        _c = c;
      }
    }
    class B {
      private A _a;
      private C _c;
      public B(A a, C c) {
        _a = a;
        _c = c;
      }
    }
    class C {
      public C() {
      }
    }
