    static IContent ParseContent(dynamic c) => ParseClass(c);
    //                           ^^^^^^^
    // This is the part where "magic" takes place
    
    IContent ParseClass(class1 c) {...}
    IContent ParseClass(class2 c) {...}
    ...
    IContent ParseClass(class20 c) {...}
    IContent ParseClass(object c) => throw new ArgumentException(...);
