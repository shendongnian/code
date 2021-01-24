    class A { public B b; }
    class B { public A a; }
    void Foo()
    {
        A a = new A();
        B b = new B();
        a.B = b;
        b.A = a;
    }
    Foo(); //both a and b are elegible for collection once Foo exists.
