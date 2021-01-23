    IQueryable<viewClass> groupedData = (from x in data
    									   group x by new
    									   {
    										   x.Code,
    										   x.Name
    
    									   } into g
    									   select new viewClass()
    									   {
    										   Id = gp.OrderByDescending(x => x.Amuont).FirstOrDefault().Id,
    										   Code = g.Key.Code,
    										   Name = g.Key.Name,
    										   Amuont = g.Max(_=>_.Amuont)
    									   });
