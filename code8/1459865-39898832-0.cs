    public class Product
    {
    	[Key]
    	public int Id { get; set; }
    	public List<ProductImage> Images { get; set; }
    }
    
    public class ProductImage
    {
    	[Key]
    	public int Id { get; set; }
    	[Key, ForeignKey("Product")]
    	public int ProductId { get; set; }
    	public string Url { get; set; }
    
    	public Product Product { get; set; }
    }
