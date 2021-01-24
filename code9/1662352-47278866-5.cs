    var info = (from t1 in Table1                
                from t2 in Table2
                join t120 in Table12 
                on new {Table1 = t1.ID, Table2 = t2.ID} equals new {t120.Table1, t120.Table2} into t12s
                from t12 in t12s.DefaultIfEmpty()
                group new { t2, t12 } by new { t1.ID, t1.Name } into sub
                select new 
                {
                    sub.Key.Name,
                    data = sub.Select(x => new { x.t2.Name, x.t12 == null ? null : x.t12.Value }).ToList()
                }).ToList();
    
    foreach(var item in info)
    {
        Console.Write($"{item.Name}\t");
        foreach(sub in item.data.OrderBy(x => x.Name))
            Console.Write($"{sub.Name}:{sub.Value}\t");
        Console.WriteLine("");
    }
