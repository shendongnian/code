    public abstract class ProductDecorator : Product
    {
        private readonly Product _product;
        public ProductDecorator(Product product)
        {
            _product = product;
        }
        public override double CalculatePrice()
        {
            return _product.CalculatePrice();
        }
    }
