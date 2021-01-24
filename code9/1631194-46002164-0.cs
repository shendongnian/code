	using System.Web.Script.Serialization;
	public class Employee 
	{
	   public int Id {get; set; }
	   public string Name {get; set; }
	   public int DepartmentId {get; set; }   
	}
	public class Department 
	{
	   public int Id {get; set; }
	   public string Name {get; set; }
	   public string CompanyId {get; set; }
	   public List<Employee> {get; set;}
	}
	public class Company {
	   public int Id {get; set; }
	   public string Name {get; set; }
	   public string Location {get; set; }
	   public List<Department> {get; set;}
	}
	var myCompany = new Company();
	// add departments and employees
	var json = new JavaScriptSerializer().Serialize(myCompany);
