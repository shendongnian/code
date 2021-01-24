    string x = "some value";
    string y = new string(x.ToCharArray());
    Console.WriteLine(x == y);                   // True
    Console.WriteLine((object) x == (object) y); // False
    Console.WriteLine(ReferenceEquals(x, y));    // False
