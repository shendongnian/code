    public class ProductsAndAveragePrice
    {
        public List<Products> Products {get;set;}
        public decimal AveragePrice {get;set;}
    }
     public ProductsAndAveragePrice GetProducts(SearchCriteria criteria)
     {
          // pretend SQL String Based repo
          var sb = new StringBuilder();
          sb.AppendLine("SELECT ProductName, Price ");
          sb.AppendLine("FROM MyProductsTable");
          sb.AppendLine("WHERE Keyword = @keyword");
          sb.AppendLine("AND From >= @from");
          sb.AppendLine("AND To <= @to");
          
          // To do
          // ...supply the parameters and execute the query
          
          var products = new List<Product>();
          foreach(var row in rows)
          {
               products.Add(new Product() {Name = row["ProductName"], Price = row["Price"]};
          }
                    
          return new ProductsAndAveragePrice(){
                     Products = products,
                     Price = products.Select(m => m.Price).Ave();
                 };
     }
