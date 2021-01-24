        public class PropertyForSale
    {
        [Key]
        public int PropertyForSaleId { get; set; }
    
        [Index("IX_pid", IsClustered = false, IsUnique = true, Order = 1), MaxLength(15)]
        public string pid { get; set; }
    
        [MaxLength(25)]
        public string Status { get; set; }
    
        public virtual PropertyRatios PropertyRatios { get; set; }
    }
    
    public class PropertyRatios
    {
        [Key, MaxLength(15)]
        public string PropertyRatiosID { get; set; }
    
        public float Zest_List_Price_Diff { get; set; }
    
        [Index]
        public DateTime LastUpdated { get; set; }
    
    }
