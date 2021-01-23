    var keys = list2.ToList();
    var toadd = list1.GroupBy(i => new { i.Name, i.Number })
                     .Where(g => !keys.Any(i => i.Name == g.Key.Name
                                             && i.Number == g.Key.Number))
                     .Select(g=>g.First());
    list2.AddRange(toadd);
