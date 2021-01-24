    public class MyController : ApiController
        {
            public HttpResponseMessage Post(Product product)
            {
                if (ModelState.IsValid)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
        }
