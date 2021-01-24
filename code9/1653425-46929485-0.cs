    public delegate IProduct ProductFactory(int id, DateTime manufacturedDate, DateTime expiryDate);
    public interface IProduct { };
    public class ConcreteProduct : IProduct
    {
        public int ProductId { get; set; }
        public DateTime ManufactureDt { get; set; }
        public DateTime ExpiryDt { get; set; }
        public ConcreteProduct(int id, DateTime manufacturedDate, DateTime expiryDate)
        {
            ProductId = id;
            ManufactureDt = manufacturedDate;
            ExpiryDt = expiryDate;
        }
    }
    //Class where Factory is injected
    public class ProductOrder
    {
        private readonly ProductFactory _prodFactory;
        public ProductOrder(ProductFactory prodFactory)
        {
            _prodFactory = prodFactory;
        }
        public IProduct GenerateOrder()
        {
            return _prodFactory.Invoke(10, DateTime.Now, DateTime.Now.AddDays(4));
        }
    }
