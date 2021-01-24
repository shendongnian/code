    var result = l1.Concat(l2)
                   .Concat(l3)
                   .GroupBy(item => new { item.id, item.Geometry }, item => item.Counter)
                   .Select(group => new Graphic
                   {
                       id = group.Key,
                       Counter = group.Sum()
                   }).ToList();
