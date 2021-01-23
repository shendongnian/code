    var particles = originalParticles.Select(p => new FP_Point()
    {
        ID = p.ID,
        ZonesIDs = p.ZonesIDs.ToList(),
        Location = new Point(p.Location.X, p.Location.Y),
        Readings = p.Readings.ToList(),
        Distance = p.Distance,
        PreviousDistance = p.PreviousDistance, 
        Weight = p.Weight
    }).ToList();
