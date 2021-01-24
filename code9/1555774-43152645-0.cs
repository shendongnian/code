    [HttpPost]
    public ActionResult MainCatItems(int mainCatNo)
    {
        entity.Configuration.ProxyCreationEnabled = false;
        var results = _model.Item.Where(x => x.MenuCategoryID == mainCatNo).ToList();
        return Json(new { data = results }, JsonRequestBehavior.AllowGet);
    }
  
