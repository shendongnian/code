    var info = (from t12 in Table12
                join t1 in Table1 on t12.Table1 equals t1.ID
                join t2 in Table2 on t12.Table2 equals t2.ID
                group new { t2, t12 } by t1.Name into sub
                select new 
                {
                    t1.Name,
                    data = sub.Select(x => new { x.t2.Name, x.t12.Value }).ToList()
                }).ToList();
    
    foreach(var item in info)
    {
        Console.Write($"{item.Name} ");
        foreach(sub in item.data)
            Console.Write($"{sub.Name}:{sub.Value} ");
        Console.WriteLine("");
    }
