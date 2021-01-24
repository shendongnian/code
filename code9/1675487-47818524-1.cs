    public class Store
    {
        private readonly Product.Immutable product;
        public Store(Product product)
        {
            this.product = product.ToImmutable();
        }
        public string Show()
        {
            return this.product.Name;
        }
    }
