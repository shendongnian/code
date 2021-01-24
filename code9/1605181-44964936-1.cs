    string x = "test";
    string y = new string(x.ToCharArray());
    Console.WriteLine(x == y); // Use string overload, checks for equality, result = true
    Console.WriteLine(x.Equals(y)); // Use overridden Equals method, result = true
    Console.WriteLine(ReferenceEquals(x, y)); // False because they're different objects
    Console.WriteLine((object) x == (object) y); // Reference comparison again - result = false
