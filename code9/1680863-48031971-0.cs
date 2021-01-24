    List<Employee> employees = new List<Employee>();
    	employees.Add(new Employee { Id = 1, Name = "John Doe", Salary = 1500 });
    	employees.Add(new Employee { Id = 1, Name = "John Wow", Salary = 1800 });
    	employees.Add(new Employee { Id = 1, Name = "Bill", Salary = 1000 });
    	employees.Add(new Employee { Id = 1, Name = "Jane Doe", Salary = 2000 });
    	
    	var secondHighestSalary=employees.OrderByDescending(e => e.Salary)
    			.Skip(2)
    			.Take(1);
    secondHighestSalary.Dump();
