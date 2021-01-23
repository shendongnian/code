    private static void StructDemo()
    {
        List<Struct22> list = new List<Struct22>();
        Struct22 s1 = new Struct22() { Property = 2, Field = 3 };  // #1
        list.Add(s1);                            // This creates copy #2
        Struct22 s3 = list[0];                   // This creates copy #3
        // Change properties:
        s1.Property = 777;
        // list[0].Property = 888;    <-- Compile error, NOT possible
        s3.Property = 999;
        Console.WriteLine("s1.Property = " + s1.Property);
        Console.WriteLine("list[0].Property = " + list[0].Property);
        Console.WriteLine("s3.Property = " + s3.Property);
    }
