    var emps = dataTable1.AsEnumerable().Select(r => new {
      EmpId = r["EmpId"].ToString(),
      EmpName = r["EmpName"].ToString(),
    });
    var depts = dataTable2.AsEnumerable().Select(r => new {
      EmpId = r["EmpId"].ToString(),
      DepartmentId = r["DepartmentId"].ToString(),
      DepartmentName = r["DepartmentName"].ToString(),
	  AddrOne = r["AddrOne"].ToString(),
	  City = r["City"].ToString(),
    });
    emps
      .Select(e => new EmployeeData {
        Emp = new Employee {
          EmployeeId = e.EmpId,
          EmployeeName = e.EmpName,
          Dep = depts.Where(w => w.EmpId == e.EmpId).GroupBy(g => new {
            DepartmentId = g.DepartmentId,
            DepartmentName = g.DepartmentName,
          })
          .Select(d => new Department {
            DepartmentId = d.Key.DepartmentId,
            DepartmentName = d.Key.DepartmentName,
            Addr = d.Select(a => new Address {
              AddrOne = a.AddrOne,
              City = a.City
            }).ToList(),
          }).ToList(),
        },
      });
