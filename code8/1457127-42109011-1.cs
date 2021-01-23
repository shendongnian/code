    public class EncryptedParameter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var obj = HttpContext.Current.Items[OBJECT_ITEM_KEY];
            HttpContext.Current.Items.Remove(AppConfig.ITEM_DATA_KEY);
            if (filterContext.ActionParameters.ContainsKey("data"))
                filterContext.ActionParameters["data"] = obj;
        }
    }
