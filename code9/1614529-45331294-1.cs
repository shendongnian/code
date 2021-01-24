    Objects[] GroupedDistinct = ungroupedObjects
        .GroupBy(line => new { 
            PickFromClientCode = line.pickupFrom.clientCode,
            LoadAtClientCode = line.LoadAt.clientCode,
            DeliverToClientCode = line.deliverTo.clientCode })
        .Select(x => x.First())
        .ToArray();
