    int a = 0;            
    int c = 0;
    object a1 = a;
    object c1 = c;
    // yes, different objects
    Console.WriteLine(a1 == c1); // false
    // still equal
    Console.WriteLine(a1.Equals(c1)); // true
