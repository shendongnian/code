    public IActionResult GetTimes(string value)
    {
        if (value == TimeSlice.ByMonth.ToString())
        {
            var l = new List<SelectListItem>
            {
                new SelectListItem {Selected = true, Text = "January", Value = "1"},
                new SelectListItem {Selected = false, Text = "February", Value = "2"}
            };
            return Json(l);
        }
        var t2 = new List<SelectListItem>
        {
            new SelectListItem {Selected = true, Text = "Q1", Value = "1"},
            new SelectListItem {Selected = false, Text = "Q2", Value = "2"}
        };
        return Json(t2);
    }
