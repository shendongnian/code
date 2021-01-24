    using (var db = new AppDbContext())
    {
        var items = await db.Branches
            .Where(b => b.OrgId == orgId)
            .Select(t => new SelectListItem<int> { Key = t.Id, Value = t.Name })
            .ToListAsync().ConfigureAwait(false);
        return items;
    }
