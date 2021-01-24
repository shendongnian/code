            public JsonResult GetEmployee(string payrollno)
    {
        var PersonsQuery = db.vwEmployee_HandoverContact.Where(x => x.Emp_Payroll_No == payrollno);
        return Json(PersonsQuery);
    }
