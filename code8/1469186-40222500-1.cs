    [Table("Barcode")]
    public partial class Barcode
    {
        [Column("_Barcode")]
        public string _Barcode { get; set; }
    
        [Column("_SkuRef")]
        [MaxLength(16)]
        public byte[] _SkuRef { get; set; }
    
        [Key]
        [Column("Id")]
        public long Id { get; set; }
    
        [Column("_SkuId")]
        [StringLength(36)]
        public string _SkuId { get; set; }
        
        public virtual SKU SKU { get; set; }
    }
    
    [Table("SKU")]
    public partial class SKU
    {
        [Column("_Code", Order = 0)]
        [StringLength(11)]
        public string _Code { get; set; }
    
        [Column("_Description", Order = 1)]
        [StringLength(150)]
        public string _Description { get; set; }
    
        [Column("_ProductId", Order = 2)]
        [StringLength(50)]
        public string _ProductId { get; set; }
    
        [Column("_Ref", Order = 3)]
        [MaxLength(16)]
        public byte[] _Ref { get; set; }
    
        [Key]
        [Column(Order = 4)]
        [StringLength(36)]
        public string Id { get; set; }
    
        public virtual ICollection<Barcode> Barcodes;
    }
