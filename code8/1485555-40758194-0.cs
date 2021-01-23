     public class MovesController : ApiController
     {
         [AcceptVerbs("GET", "POST")]
         [Route("Product")]
         public HttpResponseMessage Post([FromBody] Product product)
         {
             products.Add(product);
             newItem();
             return Request.CreateResponse(HttpStatusCode.OK, product);
         }
      }
