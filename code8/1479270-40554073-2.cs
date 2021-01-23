    var results = (from a in db.TableA 
                   join b in db.TableB on a.Id equals b.Id
                   from c in db.TableC
                   where c.Id == a.Id
                   select new MyObject {
                      ...
                   }).ToList();
