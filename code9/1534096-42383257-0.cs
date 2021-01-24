    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
