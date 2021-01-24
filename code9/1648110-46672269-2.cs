    PirateShipList2
        .Join(PirateShipList1, 
            x => x.PirateShipName, x=> x.PirateShipName,
            (s2, s1) => new
            {
                s2.Date,
                s2.PirateShipName,
                CrewMember = s1.Date == s2.Date ? s1.CrewMember : s2.CrewMember
            })
