	public Employee EmpDetails(Employee NewEmp)
	{
		Console.WriteLine("Enter Employee Name:");
		NewEmp.EmployeeName = Console.ReadLine();
		Console.WriteLine("Enter Employee Surname:");
		NewEmp.EmployeeSurname = Console.ReadLine();
		Console.WriteLine("Enter Employee Address:");
		NewEmp.Address = Console.ReadLine();
		Console.WriteLine("Enter Employee Grade:");
		NewEmp.Grade = Convert.ToInt16(Console.ReadLine());
		Console.WriteLine("Enter Employee Salary:");
		NewEmp.Salary = Convert.ToDouble(Console.ReadLine());
		// Edit here
		Console.WriteLine("Enter Department of Employee:");
		NewEmp.DepartmentOfEmployee = DepartmentFactory.CreateDepartment(Console.ReadLine());
		Console.WriteLine("Enter Employee Username:");
		NewEmp.Username = Console.ReadLine();
		Console.WriteLine("Enter Employee Password:");
		NewEmp.Password = Console.ReadLine();
	
		return NewEmp;
	}
