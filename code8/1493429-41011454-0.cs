     public class MyActionFilter : ActionFilterAttribute{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
     public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
    }
}
    
