    Console.WriteLine(((Person)a[0]).Name); // Prints "Jack"
    Console.WriteLine(((Person)b[0]).Name); // Prints "Jack"
    ((Person)a[0]).Name = "Not Jack"; // Changes the value of the object, which is 
                                      // referenced by both a and b.
    Console.WriteLine(((Person)a[0]).Name); // Prints "Not Jack"
    Console.WriteLine(((Person)b[0]).Name); // Prints "Not Jack"
