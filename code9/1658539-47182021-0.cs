        public IHttpActionResult AppsByGroup() {
            var apps = _context.Apps.OrderBy(a => a.AppOrder);
            var groups = _context.AgeGroups.OrderBy(g => g.GroupOrder);
           
            var resutl = groups.Select(x=> new { GroupId = x.Id, GroupName = x.Name, GroupOrder = x.GroupOrder, Apps = apps.Where(y=>x.Id == y.AgeGroupId).Select(y=> new { AppName = y.Name, AppIcon = y.AppIcon, StoreURL = y.StoreURL }).ToList() }).ToList();
            return Json(resutl);
        }
