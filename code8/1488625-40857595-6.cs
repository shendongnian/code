    public ActionResult Search(Criteria filter)
    {
        using (DemoDBEntities db = new DemoDBEntities())
        {
            var list = db.BMH.AsQueryable();
            if (filter != null)
            {
                if (filter.SnapshotKey.HasValue)
                    list = list.Where(r => r.SnapshotKey == filter.SnapshotKey.Value);
                if (!String.IsNullOrWhiteSpace(filter.Delq))
                    list = list.Where(r => r.Delq == filter.Delq);
            }
            list = list.OrderBy(r => r.SnapshotKey).Skip((filter.PageNo - 1) * pageSize).Take(filter.PageSize);
            ViewBag.Criteria = filter;
            return View(list.ToList());
        }
    }
