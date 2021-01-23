    public Employee Search(int EmpId)
    {
        // Return the employee with the correct Id (or null if not found).
        var e = ctx.Employees.SingleOrDefault(x=> x.EmployeeId == EmpId);
        return employeeEntity == null
            ? null
            : new Employee
              {
                  EmployeeName = e.EmployeeName,
                  EmployeeSurname = e.EmployeeSurname,
                  ...
              };
        }
    }
