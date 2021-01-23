    var response = new Employee() // Instantiates Employee to ensure correct properties used.
	{
		Id = 100, // Has PascalCase.
		Department = new DepartmentModel()
		{
			Id = 200, 
			DepartmentName = "Abc",
			Locations = Employee.Department.Locations
                                .Select(lo => new Location
                                           {
                                                 Area = lo.Area,
                                                 StreetNo = lo.StreetNo,
                                                 Nearby = lo.Nearby
                                            }
                                        ).ToList()
		}
	};
