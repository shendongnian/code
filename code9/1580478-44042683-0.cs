    public JsonResult Index(String Prefix)
    {
    List<EmployeeModels> ObjList = new List<EmployeeModels>()
    {
        new EmployeeModels {EmployeeId="1",empName="Latur" },
        new EmployeeModels {EmployeeId= "2",empName="Mumbai" },
        new EmployeeModels {EmployeeId="3",empName="Pune" },
        new EmployeeModels {EmployeeId="4",empName="Delhi" },
        new EmployeeModels {EmployeeId="5",empName="Dehradun" },
    };
    var _empId = (from N in ObjList
                    where N.empName.StartsWith(Prefix)
                  select new EmployeeModels { N.empName }).ToList();
    return Json(_empId); 
    }
