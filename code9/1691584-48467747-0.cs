    var query =
        from p in db.PartCostConfig
        group p by new { p.PartId, p.BSId } into g
        let count = g.Count()
        where count > 1
        select new
        {
            g.Key.PartId,
            g.Key.BSId,
            Count = count,
            EffectiveDate = g.Max(x => x.EffectiveDateUtc),
        };
