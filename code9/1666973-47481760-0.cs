    public class Company
    {
        [Key]
        public Guid Id { get; set; }
    
        public virtual CompanyDetail CompanyDetail { get; set; }  // This is optional
    }
    public class CompanyDetail
    {
        [Key]
        public Guid Company_Id { get; set; } 
        
    }
    ...
        modelBuilder.Entity<Company>()
            .HasOptional<CompanyDetail>(u => u.CompanyDetail)
            
