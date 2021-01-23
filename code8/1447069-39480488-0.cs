    public class MissingParamAttribute : ActionFilterAttribute
    {
       public string ParamName { get; set; }
    
       public override void OnActionExecuting(ActionExecutingContext filterContext)
       {
          if (filterContext.ActionParameters.ContainsKey(ParamName))
          {
             if (filterContext.ActionParameters[ParamName] == null)
             {
                filterContext.ActionParameters[ParamName] = 0;
             }
          }
      
       base.OnActionExecuting(filterContext);
      }
    }
