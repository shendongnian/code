    public class Customer
    {
        //other properties omitted
        public virtual ICollection<Product> Products { get; set; }
    }
    public class Product
    {
        //other properties omitted
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
