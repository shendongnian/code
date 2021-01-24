    public class BaseController :Controller
    {
       protected override void Initialize(System.Web.Routing.RequestContext requestContext)
            {
                base.Initialize(requestContext);
                Test(); check the user
            }
    }
    
    public class TestController : BaseController
    {
    }
