    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
             bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                 "~/Scripts/foo.js",
                 "~/Scripts/bar.js"
             ));
        }
    }
