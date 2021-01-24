    public class TestViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (viewLocations == null)
            {
                throw new ArgumentNullException(nameof(viewLocations));
            }
            yield return "~/Test/Test.cshtml";
        }
    }
