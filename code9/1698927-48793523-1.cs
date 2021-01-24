      public partial class ProductMangement
       {
        public ProductMangement()
        {
            this.ProductMangement1 = new HashSet<ProductMangement>();
        }
    
        public int id { get; set; }
        public int productid { get; set; }
        public Nullable<int> subproductid { get; set; }
        public string productname { get; set; }
        public virtual ICollection<ProductMangement> ProductMangement1 { get; set; }
        public virtual ProductMangement ProductMangement2 { get; set; }
    } 
