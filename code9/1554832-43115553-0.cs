    int[] first = { 1, 2, 3 };
    int[] second = null;
    
    var all = first.Concat(second); // note that query is not executed yet
    // some other code
    ...
    var name = Console.ReadLine();
    Console.WriteLine($"Hello, {name}, we have {all.Count()} items!"); // boom! exception here
