    public JsonResult SpeedData()
    {
        var speeddata = repoEntities.GetSpeedData(0, DateTime.MinValue, DateTime.MaxValue);
        return Json(speeddata.ToArray(), JsonRequestBehavior.AllowGet);
    }
