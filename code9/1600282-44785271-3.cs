    public class Company
    {
        public int CompanyID { get; set; }
    
        // Link naar de Userid in Identity: AspNetUsers.Id
        // [Display(Name = "Username")] <-- Get rid of these
        // public string UserName { get; set; } <-- get rid of these
    ...
    }
    public class ApplicationUser : IdentityUser
    {
        public int CompanyId { get; set; }
    }
