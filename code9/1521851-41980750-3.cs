    await Task.Run(()=> 
    {
        using (var db = new AppDbContext())
        {
            var items = db.Branches
                        .Where(b => b.OrgId == orgId)
                        .Select(t => new SelectListItem<int> { Key = t.Id, Value = t.Name })
                        .ToList();
            return items;
        }
    });
