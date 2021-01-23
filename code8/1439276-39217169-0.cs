    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public Guid CartID { get; set; }
        public int SkuID { set;get;}
        public virtual Sku Sku { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int CustomerID{ set;get;}
        
        public virtual Customer Customer { get; set; }
        public bool IsCheckedOut { get; set; }
    }
