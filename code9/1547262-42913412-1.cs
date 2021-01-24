    Public class MyCustomType
    {
         // assuming that there will be more properties 
         public int Id { get; set; }
         public string Name { get; set; }
    }
    // Now, Move to Controller method.
    public class CustomController : Controller 
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
         public override void OnResultExecuting(ResultExecutingContext context)
         {
              // you have to do more digging i am using dynamic to get the values and result.
              dynamic content = context.Result;
              if (content != null)
              {
                  dynamic values = content.Value;
              }
              
         }
    }
