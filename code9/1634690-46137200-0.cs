    var v = (from a in db.r1.ToList()
             join b in db.r2.ToList() on a.ID equals b.ID
              
             select new
              {
                Id = a.ID,
                month = b.Month // or a.Month as you want,
                values = a.values
              });
