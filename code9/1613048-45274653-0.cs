    public class CatalogType : AuditFields
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public bool passive { get; set; }
        [InverseProperty("catalogType")]
        public ICollection<Catalog> Catalogs { get; set; }
    
    }
    
    public class Catalog : AuditFields
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public bool passive { get; set; }
        public int order { get; set; }
        public string typeCatalogRefCode { get; set; }
        [ForeignKey("typeCatalogRefCode")]
        public virtual CatalogType catalogType { get; set; }
    }
