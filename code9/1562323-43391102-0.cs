	public class Category
	{
	    public static Category Food = new Category("Food", "apple.jpg");
	    // rest of the predefined values
	    private Category(string name, string imageName)
	    {
	        this.ImageName = imageName;
	        this.Name = name;
	    }
	    public string Name { get; private set; }
	    public string ImageName { get; private set; }
	}
    public class Product
    {
         public string Name { get; set; }
         public double Price { get; set; }
         public Category Category { get; set; }
    }
