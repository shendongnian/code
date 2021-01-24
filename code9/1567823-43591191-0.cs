    Console.WriteLine(String.CompareOrdinal(@"a-b", @"a/b"));
    Console.WriteLine(String.CompareOrdinal(@"-b",@"/b"));
    Console.WriteLine(String.CompareOrdinal(@"a-",@"a/"));
    Console.WriteLine(String.CompareOrdinal(@"-",@"/"));
    Console.WriteLine(String.CompareOrdinal(@"-/",@"/-"));
    Console.WriteLine(String.CompareOrdinal(@"--",@"//"));
