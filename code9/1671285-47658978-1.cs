    var query = (from ts in db.TimeSheets join tsd in db.TimesheetData on ts.ID  
                 equals tsd.TimeSheet.ID where ts.StartDate == thisWeekStart 
                 && ts.EndDate == thisWeekEnd select new{ tsd.Hours, tsd.Date, tsd.TaskID }).ToList();
    // var TMSSS = (string.Join(",", query.Select(x => x.ToString())));
    // ViewBag.HoursData = TMSSS;
    ViewBag.HoursData = query;
    return PartialView("~/Views/TimeSheet/_TimeSheet.cshtml", ViewBag);
