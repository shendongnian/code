    List<People> lstPeople = new List<People>
    {
        new People { Message = "[1y] Message: test messg1 Priority: top Tag: t1" },
        new People { Message = "without Message, Priority and Tag desc" }
    };
    var data = lstPeople;
    foreach (var item in lstPeople)
    {
        Console.WriteLine(item.Message);
        Console.WriteLine(item.Priority);
        Console.WriteLine(item.Tag);
    }
