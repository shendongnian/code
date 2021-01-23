    var query = (from a in context.A
                 from b in a.b
                 from c in b.c
                 from d in c.d
                 select new { a, b, c, d });
    if (!string.IsNullOrEmpty(name))
    {
        query = query.Where(record => record.b.bname.Contains(name));
    }
    if (!string.IsNullOrEmpty(keyword))
    {
        query = query.Where(record => record.c.keyword.Contains(keyword));
    }
    var result = query.ToList();
