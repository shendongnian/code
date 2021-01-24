    var FilteredList = new List<DateTime>
    {
        new DateTime(2017,3,3),
        new DateTime(2016,12,20),
        new DateTime(2017,3,5),
        new DateTime(2016,12,30),
        new DateTime(2017,3,4),
        new DateTime(2016,12,15)
    };
    
    var result = FilteredList.OrderByDescending(x => x > DateTime.Today.AddDays(-7)? 1 : 0)
        .ThenBy(x => x < DateTime.Today.AddDays(-7)
            ? -x.Ticks
            : x.Ticks);
    
    foreach (var i in result)
        Console.WriteLine(i);
    
    Console.ReadKey();
