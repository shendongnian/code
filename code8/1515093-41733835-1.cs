    string s = "g";
    string[] color = { "greena", "browna", "bluea" };
    var query = color.Where(c => c.Contains(s)).Select(x => x).ToArray();
    // Notice the ToArray() -- it forces execution of the linq which returns the results, not the query itself.
    Console.WriteLine(query.Count());
    s = "a";
    var query2 = query.Select(x => x).Where(c => c.Contains(s));
    Console.WriteLine(query2.Count());
    Console.ReadKey();
