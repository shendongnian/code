    var data = (from a in db.ModelAs
                 join b in db.ModelBs on a.Aid equals b.Aid
                 select new MyViewModel { AId = a.AId,
                             Total = b.Sum(z=>z.RequestAmount) })
              .ToList(); 
