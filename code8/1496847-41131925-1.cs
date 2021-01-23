    public class CustomerRequest
    {
        public int Id { get; set; }
        public string CorrelationId { get; set; }
        public virtual Loan Loan { get; set; }
    }
    public class CustomerRequestMap : EntityTypeConfiguration<CustomerRequest>
    {
        public CustomerRequestMap()
        {
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
    public class Loan
    {
        //public int Id { get; set; }
        [Key, ForeignKey("CustomerRequest")]
        public int CustomerRequestId { get; set; }
        public virtual CustomerRequest CustomerRequest { get; set; }
    }
    public class LoanMap : EntityTypeConfiguration<Loan>
    {
        public LoanMap()
        {
            HasRequired(m => m.CustomerRequest)
            .WithOptional(m => m.Loan)
            ;
        }
    }
