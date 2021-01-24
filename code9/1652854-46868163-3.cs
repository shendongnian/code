    var dates = new List<BCADDate>
    {
        BCADDate.Parse("0123/05/05 B.C."),
        BCADDate.Parse("2015/01/01 A.D."),
        BCADDate.Parse("2017/01/21 A.D."),
        BCADDate.Parse("2125/12/05 B.C.")
    };
    Console.WriteLine("Original ordering:");
    dates.ForEach(Console.WriteLine);
    dates.Sort();
    Console.WriteLine("------------------");
    Console.WriteLine("Sorted ordering:");
    dates.ForEach(Console.WriteLine);
    Console.Write("\nDone!\nPress any key to exit...");
    Console.ReadKey();
