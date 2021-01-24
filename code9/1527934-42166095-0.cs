    var mdl = (from age in dy.vwFacetPool
        group age by new { age.AgeGroup, age.AgeString }
        into grp
        select new AgeGroupCounts {
            AgeGroup = grp.Key.AgeGroup, 
            AgeValue = grp.Key.AgeString, 
            AgeCount = grp.Count()
        }).ToList();
