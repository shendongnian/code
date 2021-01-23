    [RoutePrefix("foo")]
    public partial class MyController : ApiController {
       //eg POST foo/bar
       [HttpPost]
       [Route("bar")]
       public async Task<MyResponseModel> BarMethod([FromBody]MyArgumentsModel arguments) {
          //...
       }
       //eg POST foo    
       [HttpPost]
       [Route("")]
       public async Task<MyResponseModel> FooMethod([FromBody]MyArgumentsModel arguments) {
           //...
       }
    }
