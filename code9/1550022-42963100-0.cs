     public static class HelperExtensions
     {
         public static string ControllerName(this HtmlHelper helper)
         {
                   string name = helper.ViewContext.Controller.GetType().Name
                   return String.Format("<span'>{0}</span>", name);
              }
         }
    }
