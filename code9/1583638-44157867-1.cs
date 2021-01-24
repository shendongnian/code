    var results = dbContext.Regions.Select(r => new RegionModel{
       Id = r.Id,
       Name = r.Name
       Districts = r.Districts.Select(d => new DistrictModel {
        .......
       })
    });
