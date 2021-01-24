    .Select(a =>
                new AggregationData()
                {
                    Parent = a.Code.Serial,
                    Children = a.AggregationChildren
                        .Select(agCh => new { agCh.Code.Serial, agCh.Position })
                        .AsEnumerable()
                        .Select(agCh => new AggregationChildrenData() { Serial = agCh.Serial, Position = agCh.Position })
                        .ToList()
                })
