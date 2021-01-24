    class Department
    {
    	public int Id { get; set; } // PK
    	// Other properties...
    }
    
    class Employee
    {
    	public int Id { get; set; } // PK
    	// Other properties...
    }
    
    class Location
    {
    	public int Id { get; set; } // PK
    	// Other properties...
    }
    
    class EmployeeDepartment
    {
    	public int EmployeeId { get; set; } // FK
    	public int DepartmentId { get; set; } // FK
    }
    
    class EmployeeLocation
    {
    	public int EmployeeId { get; set; } // FK
    	public int LocationId { get; set; } // FK
    }
