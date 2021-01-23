    var a = new MyClass(1);
    var b = new MyClass(2);
    var c = new MyClass(1);
    Console.WriteLine(a.ImplementationEquals(b)); // Prints false
    Console.WriteLine(a.ImplementationEquals(c)); // Prints true
