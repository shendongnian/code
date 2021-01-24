    var result = locations
        .SelectMany(x => x.DoctorLocations)
        .Where(y => y.fk_LocationId == id)
        .Select(x => new
        {
            K1 = x.fk_doctorId, K2 = x.fk_locationId,
            Type = "Practice",
            Priority = x.Priority ?? 0,
        })
        .OrderBy(x => x.Priority)
        .AsEnumerable() // switch to L2O
        .Select(x => new SortableItem
        {
            Keys = new List<int> { x.K1, x.K2 },
            Type = x.Type,
            Priority = x.Priority,
        })
        .ToList();
