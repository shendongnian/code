    public class PreviousPage
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public object Parameters { get; set; }
        public PreviousPage() { PP(); }
        public PreviousPage(string action, string controller, object parameters)
        {
            Action = action;
            Controller = controller;
            Parameters = parameters;
        }
        public void PP()
        {
            var htpc = HttpContext.Current.Request.RequestContext.RouteData.Values;
            object controller;
            htpc.TryGetValue("controller", out controller);
            Controller = controller as string;
            object action;
            htpc.TryGetValue("action", out action);
            Action = action as string;
            object id;
            htpc.TryGetValue("id", out id);
            int q = HttpContext.Current.Request.RawUrl.IndexOf('?');
            if (q>-1)
                Parameters = HttpContext.Current.Request.RawUrl.Substring(q+1);
            else
                Parameters = id as string;
        }
    }
