     public class BooksWithAuthersController : ApiController
     {                   
        [ResponseType(typeof(BookWithAuther))]
        public IHttpActionResult GetBooksWithAuthersById(int id)
        {
            ...
        }
       
        [ResponseType(typeof(decimal))]
        [Route("api/bookswithauthers/{id}/price")]
        public IHttpActionResult GetBooksPriceById(int id)
        {
            ...
        }
    }
