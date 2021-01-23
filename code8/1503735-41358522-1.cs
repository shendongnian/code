      public List<Employee> SearchAttendance(string fromDate, string toDate, string employeeNo)
      {
            var employee = _context.Employees
                                   .Include(i => i.EmploymentInfoes)
                                   .Include(i => i.EmploymentInfoes.Select(c => c.Trackers));
    
            if (!string.IsNullOrEmpty(fromDate))
            {
                employee = employee.Where(xx => xx.timeIn <= DateTime.Parse(fromDate));
            }
    
            if (!string.IsNullOrEmpty(toDate))
            {
                employee = employee.Where(xx => xx.timeIn >= DateTime.Parse(toDate));
            }
    
            if (!string.IsNullOrEmpty(employeeNo))
            {
                employee = employee.Where(xx => xx.employeeNo  == employeeNo);
            }
            
            return employee.ToList();   
      }
