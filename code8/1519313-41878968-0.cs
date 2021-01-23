    locations = new[]
                {
                    Employee.Department.Locations
                            .Select
                            (
                                lo => new
                                {
                                    area = lo.Area,
                                    streetNo = lo.streetNo,
                                    nearby = lo.Nearby
                                }
                            ).ToList()
                }
