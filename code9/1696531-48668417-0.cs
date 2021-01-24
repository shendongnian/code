    public class Product 
    {
       [RegularExpression("abc|abc[0-2]")]
       public string Name {get; set;}
    }
