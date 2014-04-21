using System.Web.Optimization;

namespace Kudogen.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                 "~/Content/ie10mobile.css",
                 "~/Content/bootstrap.css",
                 "~/Content/breeze.directives.css",
                 "~/Content/font-awesome.css",
                 "~/Content/toastr.css",
                 "~/Content/customtheme.css",
                 "~/Content/styles.css"));

            // TODO: Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-sanitize.js",
                //"~/Scripts/angular-cookies.js",
                //"~/Scripts/angular-loader.js",
                //"~/Scripts/angular-scenario.js",
                //"~/Scripts/angular-touch.js",
                "~/Scripts/breeze.debug.js",
                "~/Scripts/breeze.angular.js",
                "~/Scripts/breeze.directives.validation.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/toastr.js",
                "~/Scripts/moment.js",
                "~/Scripts/ui-bootstrap-tpls-{version}.js",
                "~/Scripts/spin.js",
                "~/Scripts/q.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/app.js",
                "~/app/config.js",
                "~/app/config.exceptionHandler.js",
                "~/app/config.route.js",
                "~/app/common/common.js",
                "~/app/common/logger.js",
                "~/app/common/spinner.js",
                "~/app/common/bootstrap/bootstrap.dialog.js",
                "~/app/admin/admin.js",
                "~/app/layout/shell.js",
                "~/app/layout/sidebar.js",
                "~/app/home/home.js",
                //"~/app/services/httpAuthInterceptor.js",
                "~/app/services/datacontext.js",
                "~/app/services/directives.js",
                "~/app/services/entityManagerFactory.js"
                )); 
        }
    }
}
