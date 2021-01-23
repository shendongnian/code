    var data = context.Batch
        .GroupBy(i => new {i.ItemName, i.ItemNo})
        .Select(g => new {
            ItemName = g.Key.ItemName,
            ItemNo = g.Key.ItemNo,
            Group1 = g.Where(i => i.GroupName == “Group1”).First().ItemQty,
            Group2 = g.Where(i => i.GroupName == “Group2”).First().ItemQty,
            Group3 = g.Where(i => i.GroupName == “Group3”).First().ItemQty,
            Group4 = g.Where(i => i.GroupName == “Group4”).First().ItemQty
        })
        .Where(i => i.GroupName != “”);
