      public class MyBinder : IModelBinder
      {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
          return default(int);
        }
      }
    
      public class DefaultController : Controller
      {
        public ActionResult Index([ModelBinder(typeof(MyBinder))] int? MyId)
        {
          return null;
        }
      }
