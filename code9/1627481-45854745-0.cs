    public class ProductBO : IEquatable<ProductBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Equals(ProductBO other)
        {
            return this.Id == other.Id && this.Name == other.Name;
        }
    }
