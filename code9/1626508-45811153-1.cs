    var result = myDbContext.Goods
        .Where(good => good.Name == "A")
        .GroupBy(good => good.PositionId)
        .Select(group => new
        {
            PositionId = group.Key,
            GoodsWithNameA = group.Select(groupElement => new
            {
                GoodId = groupElement.Id,
                Name = groupElement.Name,
            }),
        });
