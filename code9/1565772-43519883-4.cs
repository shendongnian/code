    public ActionResult IndexAdmin()
    {
        int userId = (int)Session["UserID"];
        userInfo = _context.UserInfo.Find(userId);    
        IEnumerable<ToursViewModel> tours = (
            from p in _context.PostsInfo
            join r in _context.Region
            on p.RegionId equals r.Id
            where r.CountryId == 1
            select new ToursViewModel
            {
                RegionName = r.CountryId,
                ImageName = p.ImageName
            });
        IndexAdminViewModel model = new IndexAdminViewModel
        {
            UserName = userInfo.username,
            Tours = tours
        };
        return View(model);
