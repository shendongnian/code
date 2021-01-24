    public class PrintPricing 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // You may want to uncomment the "navigation" properties, 
        // but I'm going to leave it commented so you know this is
        // not required for it to establish the relationship correctly, 
        // because this class represents the principal end of the relationship
        // public virtual PrintingMethod Method { get; set; }
        // public virtual PrintingSubMethod SubMethod { get; set; }
    }
    public class PrintingMethod 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Pricing")] // foreign keys go on the dependent ends for 0:1 relationships
        public int Id { get; set; }
        public virtual List<PrintingSubMethod> SubMethods { get; set; }
        public virtual PrintPricing Pricing { get; set; }
    }
    public class PrintingSubMethod
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Pricing")]
        public int Id { get; set; }
        public virtual PrintingMethod Method { get; set; }
        public virtual PrintPricing Pricing { get; set; }
    }
