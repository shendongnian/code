    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            string folderName = context.Values["ApplicationType"];
            viewLocations = viewLocations.Select(f => f.Replace("/Views/", "/" + folderName + "/"));
    
            return viewLocations;
        }
    
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var session = context.ActionContext.HttpContext.RequestServices.GetRequiredService<SessionServices>();
            string applicationType = session.GetSession<string>("ApplicationType");
            context.Values["ApplicationType"] = applicationType;
        }
    }
