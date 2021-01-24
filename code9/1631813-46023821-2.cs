    var columns = new []{""}.Concat(model.Keys);
    // columns names with the first empty column
    var rows = model
        .SelectMany(c => c.Value.Select(v => new {c.Key, v.MyKey, v.MyValue}))
        // get single cells of table
        .GroupBy(v => v.MyKey, v => v)
        // group by row name
        .Select(row => new[] {row.Key}
                           .Concat(model.Keys.Select(c =>
                                row.FirstOrDefault(r => r.Key == c)?.MyValue)));
        // create row with row name as first value
    var vm = new { Columns = columns, Rows = rows };
    return View(vm);
