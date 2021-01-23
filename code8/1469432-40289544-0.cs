    public class CreateNavigationPropertyRoutingConvention : EntitySetRoutingConvention
    {
        public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
        {
            if (odataPath.PathTemplate == "~/entityset/key/navigation" && controllerContext.Request.Method == HttpMethod.Post)
            {
                IEdmNavigationProperty navigationProperty = (odataPath.Segments[2] as NavigationPathSegment).NavigationProperty;
                controllerContext.RouteData.Values["key"] = (odataPath.Segments[1] as KeyValuePathSegment).Value; // set the key for model binding.
                return "PostTo" + navigationProperty.Name;
            }
            return null;
        }
    }
