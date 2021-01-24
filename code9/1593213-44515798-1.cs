        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
        }
    }
    public class TeachersController : ApiController
    {
        [HttpGet]
        [Route("api/teachers")]
        public HttpResponseMessage Get()
        {
            try
            {
                var _context = DemoContext.Instance;
                var teachers = _context.Teachers.ToList();
                var response = Request.CreateResponse(HttpStatusCode.OK, teachers);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
    }
