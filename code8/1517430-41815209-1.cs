    var list1 = new List<DateTime> {new DateTime(2000,1,1), new DateTime(2000, 1, 2), new DateTime(2000, 1, 3), new DateTime(2004, 5, 10) };
    var list2 = new List<string> {"A", "B" , "A" , "A" };
    
    var output = list1.Zip(list2, (time, str) => new {time, str})
        .Where(o => o.str == "A") // Change to the string you want to filter
        .Select(o => o.time)
        .ToList();
    
    foreach (var dateTime in output) {
        Console.WriteLine(dateTime);
    }
    
    Console.ReadKey();
