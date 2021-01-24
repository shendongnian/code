    var info = (from t1 in Table1
                join t120 in Table12 on t1.ID equals t120.Table1 into t12s
                from t12 in t12s.DefaultIfEmpty()
                join t20 in Table2 on t12.Table2 equals t20.ID into t2s
                from t2 in t2s.DefaultIfEmpty()
                group new { t2, t12 } by t1.Name into sub
                select new 
                {
                    sub.Key,
                    data = sub.Where(x => x.t12 != null).Select(x => new { x.t2.Name, x.t12.Value }).ToList()
                });
    
    foreach(var item in info)
    {
        Console.Write($"{item.Name} ");
        foreach(sub in item.data)
            Console.Write($"{sub.Name}:{sub.Value} ");
        Console.WriteLine("");
    }
