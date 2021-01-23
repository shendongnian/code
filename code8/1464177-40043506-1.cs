    var result =
        _db.SearchQueries
           .GroupBy(sq => new { name = sq.Clicks.Name, query = sq.Query)
           .Select(sq => new {
                               Query = sq.Query,
                               Name = sq.Clicks.Name,
                               Hits = sq.Count()
                             })
           .OrderByDescending(sq => sq.Hits);
