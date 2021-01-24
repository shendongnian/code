    A a = new A();
    a.MyParam = "Hello";
    B b = new B();
    b.MyParam = "Hello";
    A ab = new B();
    ab.MyParam = "Hello";
    MyMethod(a); // Prints Hello
    MyMethod(b); // Prints ello
    MyMethod(ab); // Prints ello
