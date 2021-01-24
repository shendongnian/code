    var results = from a in TShirt
                  join b in TShirt_Color on a.Id equals b.TShirtId into c
                  from d in c.DefaultIfEmpty()
                  join e in Color on c.ColorId equals e.Id into f
                  from g in f.DefaultIfEmpty()
                  group new {a, g} by
                  new
                  {
                       a.Id,
                       a.Name
                  } into h
                  where userSelectedColor.Contains(h.g.Id)
                  select new 
                  {
                      ID = a.Id,
                      TShirtname = a.Name,
                      AvailableColors = h.Select(i=>i.g.ColorName)
                  }
