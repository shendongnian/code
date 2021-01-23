    var resultGrouped = new List<WeightItemTotal>();
    
    var pgrouped = _context.Scores.Where(c=>c.p_id==pId)
                                   .GroupBy(a => a.PId);
    foreach (var p in pgrouped)
    {
        var grouped = p.GroupBy(f => f.CreatedDate, items => items, (key, val) 
                                                                      => new WeightItemTotal
        {
            PId = val.FirstOrDefault().PId,
            CreatedDate = key,
            TotalWeight = val.Sum(g => g.Weight)
        }).ToList();
        resultGrouped.AddRange(grouped);
    }
    return View(resultGrouped);
