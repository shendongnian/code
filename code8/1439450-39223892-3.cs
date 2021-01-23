    public ActionResult GetDistinctProperty(Expression<Func<TDomain, TProp> selector)
    {
        var query = this.InventoryService.GetAll(Deal);
        var results = query.Select(selector).Distinct().ToList();
        return Json(results, JsonRequestBehavior.AllowGet);
    }
