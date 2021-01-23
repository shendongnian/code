        [Table("Product")]
        public partial class Product
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Product()
            {
                OrderLines = new HashSet<OrderLine>();
                SKU_Table = new HashSet<Sku>();
                XREF_CatalogProduct = new HashSet<XREF_CatalogProduct>();
                ProductImages = new List<ProductImage>();
                this.Wishlists = new HashSet<Wishlist>();
    
            }
    
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
    
            [NotMapped]
            public string FormattedPrice { get { return this.Price.ToString("C"); } }
    
            [Required]
            [MaxLength]
            public string PageURL { get; set; }
    
            [Required]
            [StringLength(250)]
            public string Name { get; set; }
    
            [Required]
            public string Code { get; set; }
    
            public string Description { get; set; }
    
            public int CategoryID { get; set; }
    
            [Column(TypeName = "money")]
            [DisplayFormat(DataFormatString = "${0:#,0}", ApplyFormatInEditMode = true)]
            public decimal Price { get; set; }
    
            public DateTime? DateCreated { get; set; }
    
            public DateTime? DateModified { get; set; }
    
            [Required]        
            public bool Featured { get; set; }
    
            public virtual string ImagePath { get; set; }
    
            public virtual Category Category { get; set; }        
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<OrderLine> OrderLines { get; set; }
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Sku> SKU_Table { get; set; }
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<XREF_CatalogProduct> XREF_CatalogProduct { get; set; }
    
            public virtual ICollection<ProductImage> ProductImages { get; set; }
    
            public virtual ICollection<Wishlist> Wishlists { get; set; }
    
    
        }
