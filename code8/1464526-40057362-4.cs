    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual bool Discontinued { get; set; }
        //public virtual IList<ProductType> ProductTypes { get; set; }
        IList<ProductType> _productTypes;
        public virtual IList<ProductType> ProductTypes
        {
            get { return _productTypes ?? (_productTypes = new List<ProductType>()); }
            set { _productTypes = value; }
        }
    }
