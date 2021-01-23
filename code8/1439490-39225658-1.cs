    var volumesByPeriodAndCarrier =
        from item in items
        group item by new {item.CarrierId, item.Period}
        into grouping
        select new
        {
            grouping.Key.CarrierId,
            grouping.Key.Period,
            VolumeByType = grouping.ToDictionary(x => x.Type, x => x.Volume)
        };
