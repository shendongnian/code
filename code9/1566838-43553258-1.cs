    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/sitejs")
                //Add as many JS libraries you would like to the bundle...
                .Include("~/Scripts/jquery-3.1.1.js")
                .Include("~/Scripts/jquery-migrate-3.0.0.js")
                );
    
            bundles.Add(new StyleBundle("~/bundles/sitecss")                
                //Add as many CSS files that you would like to the bundle...
                .Include("~/css/jquery-ui.css")
                );
        }
    }
