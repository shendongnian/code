    var db = new YourDbContextHere();  // Replace your db context class here
    var parentsDictionary = db.Categories 
                              .ToDictionary(d => d.Id, v => v.Name);
    var groups = db.Categories.Select(x => x.Name)
            .Select(f => new SelectListGroup() { Name = f }).ToList();
    var itemsWithParents = (from c in db.Categories
                            join p in db.Categories
                            on c.ParentId equals p.Id
                            select new { Id = c.Id, 
                                         Text = c.Name, 
                                         ParentId = c.ParentId }).ToList();
    var groupedData = itemsWithParents
                       .Where(f => f.ParentId != 0)
                       .Select( x => new SelectListItem
                                   {
                                     Value = x.Id.ToString(),
                                     Text = x.Text,
                                     Group = groups
                                            .First(a => 
                                                    a.Name == parentsDictionary[x.ParentId])
                                   }).ToList();
    ViewBag.GroupedCategory= groupedData;
    return View();
