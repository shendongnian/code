    A a = new A();
    Console.WriteLine(a.Age()); // Invalid - not an instance of B
    B b = new B();
    Console.WriteLine(b.Age()); // Valid - an instance of B
    A ba = b;
    Console.WriteLine(ba.Age()); // Invalid
