    public class MyCustonAttributte : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            GetOwinContext().Set("RequestGUID", Guid.NewGuid());
            base.OnActionExecuting(actionContext);
        }
        public virtual IOwinContext GetOwinContext()
        {
            return HttpContext.Current.GetOwinContext();
        }
    }
