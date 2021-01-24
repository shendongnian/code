    public class Example
    {
    
      public static void CallActionMethod()
      {
        var controller = DependencyResolver.Current.GetService<AboutController>();
            controller.ControllerContext = new ControllerContext(System.Web.HttpContext.Current
            .Request.RequestContext, controller);
    
            controller.Index();
    
      }
  
    }
