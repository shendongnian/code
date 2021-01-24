	public class Company
	{
	   public int CompanyId { get; set; }
	   //...
	}
	public class Company
	{
	   public int CompanyId { get; set; }
       public string Name { get; set; }
	   //...
	}
	public class HeadOffice
	{
	   [ForeignKey(nameof(Company))]
	   public int CompanyId { get; set; }
	   public Company Company { get; set; }
       // Add Properties here
	}
	public class BranchOffice
	{
	   [ForeignKey(nameof(Company))]
	   public int CompanyId { get; set; }
	   public Company Company { get; set; }
       // Add Properties here
	}
