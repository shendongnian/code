    public class Job
    {
        public int Id { get; set; }
        public int LotNum { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public double PerHour { get; set; }
        public string Description { get; set; }
        // Navigation Helper
        public virtual ICollection<InvoiceJobRelationship> Invoices { get; set; }
    }
    public class Day
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public string Details { get; set; }
        // Navigation Helper
        public virtual ICollection<InvoiceDayRelationship> Invoices { get; set; }
    }
    public class Invoice
    {
        public int Id { get; set; }
        // Navigation Helpers
        public virtual ICollection<InvoiceJobRelationship> Jobs { get; set; }
        public virtual ICollection<InvoiceDayRelationship> Days { get; set; }
    }
    public class InvoiceDayRelationship
    {
        public int InvoiceId { get; set; }
        // Navigation Helper
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public int DayId { get; set; }
        // Navigation Helper
        [ForeignKey("DayId")]
        public Day Day { get; set; }
    }
    public class InvoiceJobRelationship
    {
        public int InvoiceId { get; set; }
        // Navigation Helper
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public int JobId { get; set; }
        // Navigation Helper
        [ForeignKey("JobId")]
        public Job Job { get; set; }
    }
