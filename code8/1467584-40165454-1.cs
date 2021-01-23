    [HttpGet]
    public JsonResult GetTime()
    {
         var data = _db.CourseTimes
             .GroupBy(c => c.Day)
             .ToDictionary(g => g.Key, v => v.Select(c => new { start = c.StartTime, stop = c.EndTime }));
        return Json(data, JsonRequestBehavior.AllowGet);
    }
