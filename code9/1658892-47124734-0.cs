    var query = (from a in dc.FRYEMPs
                         where a.EmployeeID.Equals(employeeID)
                         select a).Distinct().FirstOrDefault();
            Emp.EmployeeID = query.EmployeeID;
            Emp.EmployeeName = query.EmployeeName;
            Emp.EmployeePosition = query.EmployeePosition;
            Emp.EmployeeSalary = query.EmployeeSalary.ToString();
        }
