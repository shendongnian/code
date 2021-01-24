    var MaxOverlappingPair = pdgs.Select(pdg => new {
        Id1 = pdg[0].Key,
        Id2 = pdg[1].Key,
        OverlapInDays = pdg[0].SelectMany(d1 => pdg[1].Select(d2 => OverlappingDays((d1.DateFrom, d1.DateTo), (d2.DateFrom, d2.DateTo)))).Sum()
    }).MaxBy(TwoOverlap => TwoOverlap.OverlapInDays);
