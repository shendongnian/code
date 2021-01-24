    public class Employee
    {
    	public string EmployeeId { get; set; }
    	public string FullName { get; set; }
    	public virtual PayGroup PayGroup { get; set; } // <=
    }
