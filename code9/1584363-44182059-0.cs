     public class FacebookCheckPermission : ActionFilterAttribute
        {
            public string redirectURL { get; set; }
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.ActionParameters["Value1"] = "Hi";
                filterContext.ActionParameters["Value2"] = "Bye";
    
                base.OnActionExecuting(filterContext);
            }
    
        }
            [FacebookCheckPermission]
            public Task<ActionResult> Index(string Value1, string Value2)
            {
                string lol = $"{Value1} - {Value2}";
                return null;
    
            }
