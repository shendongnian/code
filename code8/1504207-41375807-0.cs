	var att = db.Attendances
		 .Where(d => d.Date == date)
		 .ToList() // Here
		 .Select(s => new AttendanceViewModel
		  {
			  Date = s.Date,
			  aa = DateTime.Parse(s.InTime.ToString()).ToString("HH:mm tt"),  //Error is not showing after removing this line
			  InTime = s.InTime,
			  OutTime = s.OutTime,
			  EmployeeName = s.Employee.Name,
			  EmployeeUsername = s.Employee.Username
		  })
		  .ToList();
	return Json(att);
