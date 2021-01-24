    var items = new[] {
        new { id =1, Name = "item-1"},
        new { id =2, Name = "item-2"},
        new { id =3, Name = "item-3"},
        new { id =4, Name = "item-4"}
    };
    var issues = new[] {
        new { id =1, Date = "01.01.2017"},
        new { id =2, Date = "01.02.2017"}
    };
    var joined = from item in items
                 join issue in issues on item.id equals issue.id into gj
                 from sub in gj.DefaultIfEmpty()
                 select new { item.id, item.Name, isPlanned=sub?.Date != null, sub?.Date };
    foreach (var t in joined) {
        Console.WriteLine("{0} {1} {2} {3}", t.id, t.Name, t.isPlanned, t.Date);
    }
