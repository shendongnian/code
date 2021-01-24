    public class ProductContext : ContainerContext<AutofacModule>
    {
        public IProductProvider ProductProvider { get; }
        public static ProductContext GiventServices() => new ProductContext();
        protected ProductContext()
        {
            ProductProvider = Resolve<IProductProvider>();
        }
        public List<JObject> WhenListProducts(int categoryId) => ProductProvider.List(categoryId);
    }
