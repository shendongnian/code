    // Inside Main()
    var rnd = new Random();
    Console.WriteLine(CreateDate(rnd));
    Console.WriteLine(CreateDate(rnd));
    Console.WriteLine(CreateDate(rnd));
    ...
    // Change method signature
    public static DateTime CreateDate(Random rnd) {
        DateTime date = new DateTime(1990, 1, 1);
        ... // The rest of the method remains the same
    }
