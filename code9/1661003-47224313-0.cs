    var result = listTest1.Where(l => !listTest2.Any(l2 => l2.abbrv == l.abbrv));
    var result2 = listTest2.Where(l => !listTest1.Any(l1 => l1.abbrv == l.abbrv));
    
    Console.WriteLine("objects that exist in list 1 and not list list 2, based on abbrv string");
    foreach (var t in result)
    {
        Console.WriteLine(t.abbrv);
    }
    Console.WriteLine("objects that exist in list 2 and not list list 1, based on abbrv string");
    foreach (var t in result2)
    {
        Console.WriteLine(t.abbrv);
    }
