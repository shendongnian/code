       var query = yourContext.Products.OrderByName("DESC");
       var productList = query.ToList();
       public class Product
       {
          public int Id { get;set; }
          
          public string Name { get; set; }
       }
