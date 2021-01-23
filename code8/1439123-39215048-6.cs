    public ActionResult Index(SearchModel searchModel, string sortColumn, string sortOrder)
    {
        ViewBag.SearchModel = searchModel;
        ViewBag.SearchModel = sortColumn;
        ViewBag.SortOrder = sortOrder;
        var business = new BusinessLogic();
        var model = business.Search(searchModel, sortColumn, sortOrder);
        return View(model);
    }
