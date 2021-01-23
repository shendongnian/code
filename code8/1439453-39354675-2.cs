    public ActionResult GetDistinctProperty(string propertyName)
    {
        var query = this.InventoryService.GetAll(Deal);
        var results = Enumerable.Cast<object>(
            query.SelectProperty(propertyName).Distinct()).ToList();
        return Json(results, JsonRequestBehavior.AllowGet);
    }
