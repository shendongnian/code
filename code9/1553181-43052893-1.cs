    using (var db = dbContext())
    {
        IEnumerable<MyTableRecord> rows;
        while ((rows = db.MyTable.Where(...).Skip(pageNumber++ * pageSize).Take(pageSize)).Any())
        {
            list.AddRange(rows);
        }
    }
