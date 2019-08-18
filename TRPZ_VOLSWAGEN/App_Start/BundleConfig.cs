using System.Web;
using System.Web.Optimization;

namespace TRPZ_VOLSWAGEN
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap*"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                      "~/Content/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-1.10.2.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/MyJquery").Include("~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
            "~/Scripts/script.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
          "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/style.css"));


            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                        "~/Scripts/ckeditor/ckeditor.js"));


        }
    }
}
