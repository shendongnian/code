    public class TestController : ApiController
    {
        private HttpContextBase _httpContext;
    
        public TestController ()
        {
             _httpContext = new HttpContextWrapper(HttpContext.Current);
        }
        public AuditTrailController(HttpContextBase context)
        {
            _httpContext = context;
        }
    
        [HttpGet]
        [Route("Send}")]
        public HttpResponseMessage Send()
        {
            XClass x = SessionUtils.GetSessionXProperty(_httpContext, Request.GetRouteData());
            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(x), System.Text.Encoding.UTF8, "application/json");
            return response;
        }
    }
 
