    public class Product : IEntity<Product>
    {
        public readonly Sku Sku;
        public string Name { get; private set; }
        public bool IsArchived { get; private set; }
        public Product(Sku sku, string name, bool isArchived)
        {
            Sku = sku;
            Name = name;
            IsArchived = isArchived;
        }
        public void UpdateName(string name)
        {
            Name = name;
        }
        public void UpdateDescription(string description)
        {
            Description = description;
        }
        public void Archive()
        {
            IsArchived = true;
        }
        public void Restore()
        {
            IsArchived = false;
        }
        // this is used by my framework, not MongoDB
        public Identity<Product> Identity => Sku;
    }
