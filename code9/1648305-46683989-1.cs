    Option<Employee> Employee {get; }
    
    public string ToString()
    {
    	return this.Employee.Match(e => e.Name, () => "");
    }
