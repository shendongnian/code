    var RLCaps = GetRecords()
        .GroupBy(
            record => record.Capability,
            (capability, records) => new relatedCapility
                {
                    Capability = capability ,
                    systemsRelated = records
                        .Select(record => new relatedCapabilitySystem
                            {
                                system = record.System,
                                start = record.Start,
                                end = record.End
                            })
                        .ToList()
                })
        .ToList();
