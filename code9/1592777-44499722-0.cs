    public class MyController : ApiController
    {
        public IHttpActionResult Get()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var model = new MyModel();
            return Json(model, settings);
        }
    }
