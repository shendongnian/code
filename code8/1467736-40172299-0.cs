    [HttpGet]
    public JsonResult GetTime()
    {
        var english_names = (new CultureInfo("en-US")).DateTimeFormat.DayNames
            .Select((v, i) => new { Key = i, Value = v })
            .ToDictionary(o => o.Key, o => o.Value);
        
        var arabic_names = (new CultureInfo("ar-EG")).DateTimeFormat.DayNames
            .Select((v, i) => new { Key = i, Value = v })
            .ToDictionary(o => o.Key, o => o.Value);
        var data = _db.CourseTimes
            .GroupBy(c => c.Day)
            .ToDictionary(g => english_names.FirstOrDefault(p => p.Key == arabic_names.FirstOrDefault(a => a.Value == g.Key).Key).Value, v => v.Select(c => new
            {
                start = TimeSpan.FromHours(c.StartTime).ToString("hh':'mm"),
                stop = TimeSpan.FromHours(c.EndTime).ToString("hh':'mm")
            }).ToList());
        return Json(data, JsonRequestBehavior.AllowGet);
    }
