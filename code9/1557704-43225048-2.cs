    List<DistrictDetails> districtsAssigned = _context.UserDistricts
        .Where(x=>x.Userid == userId) 
        .Select(y=> new DistrictDetails 
             {
                DistrictId==y.Districts.DistrictId,
                DistrictName=y.Districts.DistrictName,
                userId == y.d
             }).ToList();
