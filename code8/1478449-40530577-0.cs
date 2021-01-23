            RootObject Employees = JsonConvert.DeserializeObject<RootObject>(jsonEmployees);
            List<Employee> EmployeesNew = new List<Employee>();
            foreach (var item in Employees.Employees)
            {
                string StringAddress = JsonConvert.SerializeObject(item.Address, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                EmployeesNew.Add(new Employee { EmpId = item.EmpId, EmpName = item.EmpName, AddressString = StringAddress });
            }
