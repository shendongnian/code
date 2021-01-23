    public ActionResult DaywiseData(DateTime date)
    {
        try
        {
            var att = db.Attendances
                     .Where(d => d.Date == date)
                     .Select(s => new AttendanceViewModel
                      {
                          Date = s.Date,
                          DateTime s.InTime, //dateTime property
                          DateTimeString = string.Empty //string property
                          InTime = s.InTime,
                          OutTime = s.OutTime,
                          EmployeeName = s.Employee.Name,
                          EmployeeUsername = s.Employee.Username
                      })
                      .ToList();
             att.ForEach(a => a.DateTimeString = a.DateTime.ToString("HH:mm tt"));
    
             return Json(att);
         }
         catch (Exception ex)
         {
             return Json(ex.Message);
         }
    }
