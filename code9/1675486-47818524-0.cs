    public class Product
    {
        public string Name { get; set; }
        
        public Immutable ToImmutable() => new Immutable(this);
        
        public class Immutable
        {
             public Immutable(Product product) { Name = product.Name; }
             public string Name { get; }
        }
    }
