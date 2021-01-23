     public class ProductsController : ApiController
        {
            public HttpResponseMessage Post(Product product)
            {
                if (ModelState.IsValid)
                {
                     return new HttpResponseMessage(HttpStatusCode.OK);
                }
             }
        }
     
