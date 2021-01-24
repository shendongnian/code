    //Prepare
    var items = new List<C1>();
    items.Add(new C1 { Day = 1, Tip = 2, Result = 2000 });
    items.Add(new C1 { Day = 1, Tip = 1, Result = 3000 });
    items.Add(new C1 { Day = 2, Tip = 3, Result = 4000 });
    items.Add(new C1 { Day = 2, Tip = 4, Result = 5000 });
    items.Add(new C1 { Day = 2, Tip = 4, Result = 8000 });
    //Group the days
    var days = items.GroupBy(o => o.Day).Select(o => o.Key).ToList();
    //Group the data on Tip
    var tip = items.GroupBy(o => o.Tip, o => o.Result, (key, g) => new { Name = key, Data = g.ToList() }).ToList();
