    public class ControllerDisplayNameAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = Name;
            if (string.IsNullOrEmpty(name))
                name = filterContext.Controller.GetType().Name;
            filterContext.Controller.ViewData["ControllerDisplayName"] = Name;
            base.OnActionExecuting(filterContext);
        }
    }
