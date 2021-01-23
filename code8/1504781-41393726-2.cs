    public class MyViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            yield return "/View1/{1}/{0}.cshtml";
            yield return "/View1/Shared/{0}.cshtml";
        }
        public void PopulateValues(ViewLocationExpanderContext context)
        {            
        }
    }
