    var items = new List<Item>
    {
        new Item { DateTime = DateTime.Parse("01/01/18 12:01:10") },
        new Item { DateTime = DateTime.Parse("01/01/18 12:01:20") },
        new Item { DateTime = DateTime.Parse("01/01/18 12:01:30") },
        new Item { DateTime = DateTime.Parse("01/01/18 12:02:45") },
        new Item { DateTime = DateTime.Parse("01/01/18 12:05:00") },
        new Item { DateTime = DateTime.Parse("01/01/18 12:07:30") },
        new Item { DateTime = DateTime.Parse("01/01/18 12:09:00") },
        new Item { DateTime = DateTime.Parse("01/01/18 12:14:00") }
    };
    
    foreach (var item in ClosestTo(items, new TimeSpan(0, 5, 0)))
    {
        Console.WriteLine($"DateTime: {item.DateTime}");
    }
