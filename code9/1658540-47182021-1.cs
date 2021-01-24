    public IHttpActionResult AppsByGroup() {
       var apps = _context.Apps.OrderBy(a => a.AppOrder);
       var groups = _context.AgeGroups.OrderBy(g => g.GroupOrder);
       var result = groups.Select(x => new {
             AgeGroupName = x.Name,
             Apps = apps
               .Where(y => x.Id == y.AgeGroupId)
               .Select(y => new {
                  AppName = y.Name,
                  AppIcon = y.AppIcon,
                  StoreURL = y.StoreURL
                })
             });
       return Json(result);
    }
