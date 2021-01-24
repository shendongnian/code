    public class Company
    {
       public int CompanyId { get; set; }
       public string CompanyName { get; set; } 
       public int? ParentCompanyId { get; set; }
       [ForeignKey("ParentCompanyId")]
       public virtual Company ParentCompany { get; set; }
    }
