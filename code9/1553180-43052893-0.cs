    cosnt int cnt = 10000;
    const int pageSize = 1000;
    int pageNumber = 0;
    var list = new List<MyTableRecord>();
    using (var db = dbContext())
    {
        for (var i = 0; i < cnt ; i++)
        {
            vary query = db.MyTable.Where(...).Skip(pageNumber++ * pageSize).Take(pageSize);
            list.AddRange(await query.ToArrayAsync());
        }
    }
