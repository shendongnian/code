    public class Product : EntityBase<Product, int>, IAggregateRoot
    {
        public virtual string ProductName { get; set; }
      //public virtual List<ProductDetail>  Description { get; set; }
        public virtual IList<ProductDetail> Description { get; set; }
    }
