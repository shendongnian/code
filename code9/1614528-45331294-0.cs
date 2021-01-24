    Objects[] GroupedDistinct = ungroupedObjects
        .GroupBy(line => new { 
            PickFromClientCode = object.pickupFrom.clientCode,
            LoadAtClientCode = object.LoadAt.clientCode,
            DeliverToClientCode = object.deliverTo.clientCode })
        .Select(x => x.First())
        .ToArray();
