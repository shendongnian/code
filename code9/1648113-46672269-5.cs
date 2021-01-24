    PirateShipList2
        .Select(s2 => new 
        { 
            s2, 
            s1 = PirateShipList1.FirstOrDefault(s1 => 
                s1.PirateShipName == s2.PirateShipName &&
                s1.Date == s2.Date)
        })
        .Select(x => new
        {
            x.s2.Date,
            x.s2.PirateShipName,
            CrewMember = x.s1 != null ? x.s1.CrewMember : x.s2.CrewMember
        })
