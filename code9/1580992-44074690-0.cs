    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(Bundles.ShippingMemo).Include(
                        "~/Scripts/App/Main.js"
                ));
            bundles.Add(new ScriptBundle(Bundles.GiftCard).Include(
                        "~/Scripts/App/GiftCard.js"
                ));
            bundles.Add(new ScriptBundle(Bundles.JqueryJS).Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle(Bundles.JqueryUI).Include(
                        "~/Scripts/jquery-ui-{version}.js"));
            bundles.Add(new ScriptBundle(Bundles.JqueryValidate).Include(
                        "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(Bundles.Modernizr).Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle(Bundles.BoostrapJS).Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle(Bundles.DataTablesJS).Include(
                    "~/Scripts/jquery.dataTables.js"));
            bundles.Add(new StyleBundle(Bundles.CSS).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/fonts.css"
                      )
                      .Include("~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle(Bundles.DataTablesStyle).Include(
                "~/Content/Datatables/jquery.dataTables.css"));
            //bundles.UseCdn = true;
            //BundleTable.EnableOptimizations = true;
            //bundles.Add(new StyleBundle("~/bundles/azalea39",
            //"http://azalea.com/web-fonts/Code39Azalea.min.css"
            //).Include(
            // "~/Scripts/azalea39"));
        }
    }
    public static class Bundles
    {
        public const string CSS = "~/Content/css";
        public const string DataTablesStyle = "~/Content/datatables/css";
        public const string DataTablesJS = "~/bundles/datatables";
        public const string BoostrapJS = "~/bundles/bootstrap";
        public const string JqueryJS = "~/bundles/jquery";
        public const string JqueryUI = "~/bundles/jqueryui";
        public const string JqueryValidate = "~/bundles/jqueryval";
        public const string Modernizr = "~/bundles/modernizr";
        public const string ShippingMemo = "~/bundles/App/Main";
        public const string GiftCard = "~/bundles/App/GiftCard";
    }
