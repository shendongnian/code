    var RLCaps = GetRecords()
        .GroupBy(record => record.Capability)
        .Select(grouping => new relatedCapility
            {
                Capability = grouping.Key,
                systemsRelated = grouping
                    .Select(record => new relatedCapabilitySystem
                        {
                            system = record.System,
                            start = record.Start,
                            end = record.End
                        })
                    .ToList()
            })
        .ToList();
