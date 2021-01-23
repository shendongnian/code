    var result = filenames.Select(s =>
    {
        var splitted = s.Split('_');
        return new
        {
            ProductId = splitted[2],
            Subformat = splitted[3],
            Language = splitted[4],
            DateTime = DateTime.ParseExact(splitted[5], "MMddyyyyHHmmss", null),
            Source = s
        };
    })
    .GroupBy(a => new { a.ProductId, a.Subformat, a.Language })
    .Select(g => g.First(a => a.DateTime == g.Max(b => b.DateTime)).Source)
    .ToList();
