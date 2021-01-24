    if (message is MyClass)
    {
        MyClass obj = message as MyClass;
        MyType type = obj.Type;
        // Dome Action
    }
    else if (message is MyClass1)
    {
        MyClass1 obj = message as MyClass1;
        MyType1 type = obj.Type;
        // Some Action
    }
