    [OutputCache(Location = OutputCacheLocation.Client, VaryByParam = "id;query", Duration = 60)]
    public JsonResult GetBusinessLineList(string id = null, string query = null)
    {
        return Json(Db.BusinessLine.AsQueryable()
            .Where(x => x.Label.Contains(query))
            .Take(10)
            .Select(x => new { id = x.BusinessLineId, text = x.Label })
            .ToList(), 
            JsonRequestBehavior.AllowGet);
    }
