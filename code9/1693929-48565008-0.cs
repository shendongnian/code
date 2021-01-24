    public class CompanyConfiguration: EntityTypeConfiguration<Company>
    {
       public CompanyConfiguration()
       {        
            this.ToTable("COMPANY_PROFILE");
            this.Property(p => p.WorkingCompany)
                    .HasColumnName("COMPANY_NAME");
       }
     }
