    var data = _context.Apps
        .OrderBy(x => x.AgeGroup.GroupOrder) // order by AgeGroup first
        .ThenBy(x => x.AppOrder) // then by the AppOrder
        .GroupBy(x => x.AgeGroup.Name) // group by the AgeGroup
        .Select(x => new AgeGroupVM // project into the view model
        {
            Name = x.Key,
            Apps = x.Select(y => new AppVM
            {
                Name = y.Name,
                StoreURL = y.StoreURL,
                AppIcon = y.AppIcon
            })
        });
    return Json(data);
