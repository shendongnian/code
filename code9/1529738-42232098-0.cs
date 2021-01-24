    var employeesByDepartment = from d in Department.GetAllDepartments()
                                    join e in Employee.GetAllEmployees()
                                    on d.ID equals e.DepartmentID into eGroup
                                    select new
                                    {
                                        Department = d,
                                        Employees = eGroup.ToList()
                                    };
