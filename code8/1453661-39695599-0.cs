    public class MySessionCheckFilterAttribute : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext context)
       {
    
           //Check Session Method()
           //if(SessionNotAvaliable)
           //{
           //    throw new businessException;
           //}
                    
           base.OnActionExecuting(context);
        }
    }
    
    [MySessionCheckFilterAttribute]
    public class BaseController:Controller
    {
              
    }
    
    public class YourController_One: BaseController
    {
        //Do anything
    }
           
    public class YourController_Two : BaseController
    {
        //Do anything
    }
