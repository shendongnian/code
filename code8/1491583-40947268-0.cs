    public class Product
    {
    public Product(){
    category = new List<Category>();
    }
    public int ProductID {get; set;}
    public string Name {get; set;}
    public List<Category> category {get; set;}
    }
