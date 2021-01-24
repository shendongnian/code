    public class CamelCasingFilterAttribute:ActionFilterAttribute
        {
            private JsonMediaTypeFormatter _camelCasingFormatter = new JsonMediaTypeFormatter();
    
            public CamelCasingFilterAttribute()
            {
                _camelCasingFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
    
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                ObjectContent content = actionExecutedContext.Response.Content as ObjectContent;
                if (content != null)
                {
                    if (content.Formatter is JsonMediaTypeFormatter)
                    {
                        actionExecutedContext.Response.Content = new ObjectContent(content.ObjectType, content.Value, _camelCasingFormatter);
                    }
                }
            }
        }
 
  
      public class ValuesController : ApiController
        {
            // GET api/values
            [CamelCasingFilter]
            public IEnumerable<Test> Get()
            {
                return new Test[] {new Test() {Prop1 = "123", Prop2 = "3ERr"}, new Test() {Prop1 = "123", Prop2 = "3ERr"}};  
            }
    
            // GET api/values/5
            
            public Test Get(int id)
            {
    
                return new Test() {Prop1 = "123", Prop2 = "3ERr"};  
            }
        }
    
        public class Test
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
        }
