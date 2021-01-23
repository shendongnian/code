    public class DepartmentDescription
    {
       [Key]
       [Column(Order = 1)]
       public Guid DepartmentID { get; set; }
       [Key]
       [Column(Order = 2)]
       public Int32 LocaleID { get; set; }
       public String Description { get; set; }
       // Navigation Properties
       [ForeignKey("DepartmentID"), Required]
       public virtual Department Department { get; set; }
       [ForeignKey("LocaleID"), Required]
       public virtual Locale Locale { get; set; }
    }
