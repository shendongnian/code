    public class Customer
    {
        //other properties omitted
        public virtual ICollection<Product> Products { get; set; }
    }
    public class Product
    {
        //other properties omitted
        public virtual Customer Customer { get; set; }
    }
