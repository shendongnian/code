    public class Brand
    {
        public int Id { get; set; }
        public virtual Image Image { get; set; }
        public int ImageId { get; set; }
    }
    public class Image
    {
        public int Id { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public virtual Image Image { get; set; }
        public virtual Brand Brand { get; set; }
        public int ImageId { get; set; }
        public int BrandId { get; set; }
    }
