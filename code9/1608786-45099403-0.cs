    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            // Route parsing convention for view engines:
            // {0} means action method name
            // {1} means controller class name
            // {2} means area name
            AreaMasterLocationFormats = new[] 
            {
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            AreaViewLocationFormats = new[] 
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                // other view search locations here
            };
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
        }
    }
