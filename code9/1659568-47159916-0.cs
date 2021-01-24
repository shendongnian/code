    public class Product
    {
        public Product(int id = -1)
        {
            Id = id;
            IsDefault = id == -1;
        }
        public int Id { get; private set; }
        public bool IsDefault { get; private set; }
    }
