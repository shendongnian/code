    public class ViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var locationWithoutController = "/Views/{0}.cshtml";
            return viewLocations.Union(new[] { locationWithoutController });
        }
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
    }
