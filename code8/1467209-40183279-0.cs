    var query = ctx.Filters.Where(x => x.SessionId == id)
        .Join(ctx.Items, i => i.ItemId, fs => fs.Id, (f, fs) => fs);
    query.Select(x => x.ItemNav1).Load();
    query.Select(x => x.ItemNav2).Load();
    query.Select(x => x.ItemNav3).Load();
    query.Select(x => x.ItemNav4).Load();
    query.Select(x => x.ItemNav5).Load();
    query.Select(x => x.ItemNav6).Load();
    var result = query.ToList();
