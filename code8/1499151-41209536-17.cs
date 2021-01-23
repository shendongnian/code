    var data = (from a in db.ModelAs
                join b in db.ModelBs on a.AId equals b.AId
                    group b by a.AId into g
        select new MyViewModel { AId = g.Key, Total = g.Select(f=>f.RequestAmount).Sum() })
            
    .ToList(); 
