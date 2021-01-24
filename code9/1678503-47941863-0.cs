    public class Company
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<CompanyDepartment> DepartmentLinks { get; set; }
    }
    
    public class Department
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<CompanyDepartment> CompanyLinks { get; set; }
    }
    
    public class BusinessUnit
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public bool IsPersonal { get; set; }
    	public ICollection<CompanyDepartment> CompanyDepartments { get; set; }
    }
    
    public class CompanyDepartment
    {
    	public int CompanyId { get; set; }
    	public int DepartmentId { get; set; }
    	public Company Company { get; set; }
    	public Department Department { get; set; }
    	public ICollection<BusinessUnit> BusinessUnits { get; set; }
    }
