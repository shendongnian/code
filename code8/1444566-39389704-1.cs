    var particles = originalParticles.Select(p => new FP_Point()
    {
        ID = p.ID,
        ZonesIDs = p.ZonesIDs != null ? p.ZonesIDs.ToList() : null,
        Location = new Point(p.Location.X, p.Location.Y),
        Readings = p.Readings != null ? p.Readings.ToList() : null,
        Distance = p.Distance,
        PreviousDistance = p.PreviousDistance, 
        Weight = p.Weight
    }).ToList();
