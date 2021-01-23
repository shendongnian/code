    from c in _db.TimeSheetHeaders
    group c by c.BatchID into grp
    where grp.Count() > 1
    select new
    {
        BatchID = g.Key,
        Count = grp.Count(),
        TimeSheetCreationDate = grp.Min(x => x.TimeSheetCreationDate)
    }
