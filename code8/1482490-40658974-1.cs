    var merged = 
        from item in FirstLink.Concat(SecondLink)
        group item by new { Id = item.TableId, Name = item.TableName } into tbGp
        select new LinkedTable
        {
            TableId = tbGp.Key.Id,
            TableName = tbGp.Key.Name,
            innerLinks = tbGp.SelectMany(p => p.innerLinks).Distinct().ToList()
        };
