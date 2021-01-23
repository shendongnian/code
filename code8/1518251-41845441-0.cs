        var list = new List<int> { 1, 2, 3 };
        var list2 = new List<int>();
        Console.WriteLine(list.First()); //Prints 1
        //Console.WriteLine(list2.First());  <- Throws an error
        Console.WriteLine(list.FirstOrDefault()); //Prints 1
        Console.WriteLine(list2.FirstOrDefault()); //Prints 0
        Console.Read();
