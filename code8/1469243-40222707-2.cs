    var query = (from a in A
                 from b in (List<dynamic>)a.b
                 from c in (List<dynamic>)b.c
                 from d in (List<dynamic>)b.d
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
