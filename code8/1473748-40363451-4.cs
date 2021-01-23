    Test test = new Test();
    Console.WriteLine(!test); // Prints "True"
    if (test)
        Console.WriteLine("This is not printed");
    test.Value = 1;
    Console.WriteLine(!test); // Prints "False"
    if (test)
        Console.WriteLine("This is printed");
