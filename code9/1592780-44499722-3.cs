    public class CustomJsonAttribute : Attribute, IControllerConfiguration 
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            var formatter = controllerSettings.Formatters.JsonFormatter;
                
            controllerSettings.Formatters.Remove(formatter);
            
            formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };
            
            controllerSettings.Formatters.Insert(0, formatter);
        }
    }
    
    [CustomJson]
    public class MyController : ApiController
    {
        public IHttpActionResult Get()
        {
            var model = new MyModel();
            return Ok(model);
        }
    }
