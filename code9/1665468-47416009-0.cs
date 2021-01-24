    class Supplier
    {
        public int Id {get; set;}
        // Every Supplier has zero or more ProductSupplierTables:
        public virtual ICollection<ProductSuppierTable> ProductSupplierTables {get; set;}
 
        public string SupplierName {get; set;}
        ...
    }
    class ProductSupplier
    {
        public int Id {get; set;}
        // every ProductSupplier belongs to exactly one Supplier using foreign key
        public virtual Supplier Supplier {get; set;}
        public int SupplierId {get; set;}
        public string SupplierRef {get; set;}
        ...
    }
