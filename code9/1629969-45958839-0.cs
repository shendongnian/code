    public class YcoPageIdAttribute : ActionFilterAttribute
    {
        public YcoPageIdAttribute(int pageId)
        {
            PageId = pageId;
        }
        public int PageId { get; }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                filterContext.Controller.TempData[DomainKeys.ViewPageId] = PageId;
            }
            else 
            {
                throw new Exception("Only ViewResult has unique id");
            } 
            base.OnActionExecuted(filterContext);
        }
    } 
