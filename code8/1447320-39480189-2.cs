    [Table("Wishlist")]
    public class Wishlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
    
        [StringLength(100)]
        public string Name { get; set; }
    
        public int CustomerID { get; set; }
    
        [Required]
        public Customer Customer { get; set; }
    
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime CreateDate { get; set; }
    
    
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime LastModifiedDate { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    
    }
