    db.PunchSet
        .Include(x => x.Contractor)
        // ... other includes of complete objects
        // then select properties for partial include
        .Select(x => new { obj = x, att = x.Attachments.Select(a => new { a.Id, a.Name }) })
        // end of database query context
        .AsEnumerable()
        // join the results in memory
        .Select(x =>
        {
            x.obj.Attachments = x.att.Select(a => new Attachment() { Id = a.Id, Name = a.Name }).ToList();
            return x.obj;
        });
