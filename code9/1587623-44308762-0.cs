    public class Drink : Product
    {
        public int BrandId { get; set; }
        // Navigational properties
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<DrinkTag> DrinkTags { get; set; }
    }
