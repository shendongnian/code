    string[] names = // ...
    string name = //...
    // Explicit calling
    int idx = BinarySearch<string>(names, name);
    // Implicit calling
    // The following option works because the C# compiler can tell you are
    // using two values of type string and inserts the correct generic
    // type for you
    int idx = BinarySearch(names, name);
