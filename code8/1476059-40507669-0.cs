    public class BundleConfig
        {
            // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
            public static void RegisterBundles(BundleCollection bundles)
            {
                var styles = new string[]
                {
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap-select.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/toastr.min.css",
                    "~/Content/front.css",
                    "~/Content/style.css"
                };
    
                var zocial = new string[] { "~/Content/zocial.css" };
    
                var gridmvc = new string[]
                {
                    "~/Content/Gridmvc.css",
                    "~/Content/gridmvc.datepicker.min.css"
                };
    
                bundles.Add(new StyleBundle("~/Content/stylesheets").Include(styles));
                bundles.Add(new StyleBundle("~/Content/stylesheets-zocial").Include(styles.Concat(zocial).ToArray()));
                bundles.Add(new StyleBundle("~/Content/stylesheets-gridmvc").Include(styles.Concat(gridmvc).ToArray()));
    
    
            }
    }
    public static class BundleExtensions
    {
            public static string GetViewBundleName(this System.Web.Mvc.HtmlHelper helper, int langId, BundleType bundleType)
            {
                var controller = helper.ViewContext.RouteData.Values["controller"].ToString();
                var action = helper.ViewContext.RouteData.Values["action"].ToString();
    
                        switch (controller.ToLower())
                        {
                            case "home":
                                {
                                    switch (action.ToLower())
                                    {
                                        case "index": return "~/Content/stylesheets-homepage";
                                        default:
                                            return "~/Content/stylesheets";
                                    }
                                }
                            case "sitemaps":
                                return "~/Content/stylesheets-zocial";
    
                            case "blogs":
                                return "~/Content/stylesheets-gridmvc";
    
                            case "account":
                                return "~/Content/stylesheets-jqueryval";
   
    
                            default:
                                return "~/Content/stylesheets";
                        }
            }
    }
