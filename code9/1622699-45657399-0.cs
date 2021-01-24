    var q = from p in concatlist
            group p by new { p.Empid, p.Empname} into g
            select new 
            {
               Empid = g.Key.Empid,
               Empname = g.Key.Empname,
               Rating = g.Sum(c=>c.Rating)
            };
