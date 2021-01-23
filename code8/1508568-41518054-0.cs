    public class ProductController : Controller
    {
      public ViewResult Product(long productId) 
      {
          var product = FindProduct(productId);
          var productView = GetRelevantProductView((dynamic)product);
          return productView; 
      }
     
      private void GetRelevantProductView(Book book)
      {
        return View("BookView", book);
      }
    
      private void GetRelevantProductView(Game game)
      {
        return View("GameView", game);
      }
  
}
