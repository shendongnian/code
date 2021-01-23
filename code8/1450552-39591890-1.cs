    [System.Web.Http.RoutePrefix("foo")]
    public partial class MyController : ApiController {
       //eg POST foo/bar
       [System.Web.Http.HttpPost]
       [System.Web.Http.Route("bar")]
       public async Task<MyResponseModel> BarMethod([FromBody]MyArgumentsModel arguments) {
          //...
       }
       //eg POST foo    
       [System.Web.Http.HttpPost]
       [System.Web.Http.Route("")]
       public async Task<MyResponseModel> FooMethod([FromBody]MyArgumentsModel arguments) {
           //...
       }
    }
