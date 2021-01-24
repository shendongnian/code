    things = _context.Things.OrderBy(b => b.Name)
    .Select(b => new ThingViewModel
    {
         Id = b.Id,
         Name = b.Name,
         SubThings =b.SunThings.Select(st=>new SubThingViewModel{Id =st.Id,...}).ToList()
    }).ToList();
