using System.Web;
using System.Web.Optimization;

namespace RunClub
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region Template Design

            bundles.Add(new ScriptBundle("~/template/js").Include(
                       "~/js/jquery-1.11.2.min.js",
                       "~/js/bootstrap.js",
                       "~/js/jquery.main.js"));


            bundles.Add(new StyleBundle("~/template/css").Include(
                   "~/css/bootstrap.css",
                    "~/fonts/font-awesome-4.3.0/css/font-awesome.min.css",
                    "~/css/all.css"

                    ));

            #endregion
        }
    }
}
