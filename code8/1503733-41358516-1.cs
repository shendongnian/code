     public List<Employees> SearchAttendance(string fromDate, string toDate, string employeeNo)
     {
          var employees = _context.Employees
                           .Include(i => i.EmploymentInfoes)
                           .Include(i => i.EmploymentInfoes.Select(c => c.Trackers))
                           .Select(i=> new { // your properties you need })
                           .AsQueryable();
          if (fromDate != "")
          {
              employees = employees.where(t => t.timeIn >= DateTime.Parse(fromDate));
          }
          if (toDate != "")
          {
                employees = employees.where(t => t.timeIn <= DateTime.Parse(toDate));
          }
          if (employeeNo != "")
          {
                employees = employees.where(t => t.employeeNo == employeeNo);
          }
           return employees.ToList();
     }
