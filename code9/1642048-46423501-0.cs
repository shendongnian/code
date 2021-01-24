     public static void RegisterBundles(BundleCollection bundles)
        {
        bundles.Add(new ScriptBundle("~/bundles/Filter").Include(
                   "~/Scripts/UIScripts/Module1/MainFilter1.js",
                   "~/Scripts/UIScripts/Module2/MainFilter2.js",
                   "~/Scripts/UIScripts/Module3/MainFilter3.js"
                   ));
        BundleTable.EnableOptimizations = true;
        }
