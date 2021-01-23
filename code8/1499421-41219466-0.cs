    var aggregatedItems = items.GroupBy(x => new { x.Code, x.Period })
                .Select(g => new
                {
                    Code = g.Key.Code,
                    Period = g.Key.Period,
                    Value = g.Sum(y => y.Value)
                });
