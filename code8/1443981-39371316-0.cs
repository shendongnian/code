    db.PunchSet
        .Include(x => x.Contractor)
        // ... other includes of complete objects
        // then select properties for partial include
        .Select(x => new { obj = x, att = x.Attachments.Select(a => new Attachment() { Name = a.Name }) })
        // end of database query context
        .AsEnumerable()
        // join the results in memory
        .Select(x =>
        {
            x.obj.Attachments = x.att.ToList();
            return x.obj;
        });
