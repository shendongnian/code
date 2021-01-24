    Public class MyCustomType
    {
         // assuming that there will be more properties 
         public int Id { get; set; }
         public string Name { get; set; }
    }
    // Now, Move to Controller method.
    public class CustomController : ApiController 
    {
        [HttpGet({"id"})]
        [MyFilter]
        public async Task<MyCustomType> Load(string id)
        {
           // Do some async operations 
           // Or do some Db queries 
           // returning MyCustomType
           MyCustomType typeToReturn = new MyCustomType();
           typeToReturn.Id = 1;
           typeToReturn.Name = "something";
           
           return typeToReturn;
        }
    } 
     // Well here goes the attribute
    public class MyFilterAttribute : ActionFilterAttribute
    {
         public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
         {
              var content = actionExecutedContext.Response.Content as ObjectContent;
              if (content != null)
              {
                  var type = content.ObjectType; // gets the type
                  var value = content.Value; // here you gets your values on your type
              }
              
              // further you can get the status code as well 
              var statusCode = actionExecutedContext.Response.StatusCode.ToString();
         }
    }
