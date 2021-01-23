    var intClass = new SomeGenericClass<int>();
    intClass.Printer.Print();
    // Output: Specialized with int
    var doubleClass = new SomeGenericClass<double>();
    doubleClass.Printer.Print();
    // Output: Specialized with double
    var stringClass = new SomeGenericClass<string>();
    stringClass.Printer.Print();
    // Output: Unspecialized method
