    //Result Type: List<IEnumerable<GoodGroup>>
    var res = db.Goods
                    .GroupBy(r => r.GoodGroupId)
                    .Select(grp => grp
                        .Select(m => new GoodGroup
                        {
                            Id = m.Id,
                            Name = m.Name,
                            Code = m.Code
                        }))
                    .ToList();
