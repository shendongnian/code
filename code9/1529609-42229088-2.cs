    public ActionResult Locations(int locationId, int poHeaderId = 0)
    {
        var locList = StockMovesHeaderViewModelHelper.GetLocations(db, locationId, poHeaderId);
        var tmpList = new SelectListWithSelect(true);
        foreach (var l in locList)
        {
            tmpList.Add(new SelectListItem { Text = l.Description, Value = l.FulfilmentLocationID.ToString() });
        }
        return Json(tmpList, JsonRequestBehavior.AllowGet);
    }
