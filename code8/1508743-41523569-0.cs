    public class ProductViewModel{
    public string Name { get; set; }
    public Byte[] Image { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    }
