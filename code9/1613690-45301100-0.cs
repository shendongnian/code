    public class MyApiController : ApiController {
        public IHttpActionResult MyExampleAction() {
            var LoginResponse = new object();//Replace with your model
            var cookie = new CookieHeaderValue("name", "value");//Replace with your cookie
            //Create response as usual
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, LoginResponse);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.AddCookies(new[] { cookie });
            //Use ResponseMessage to convert it to IHttpActionResult
            return ResponseMessage(response);
        }
    }
