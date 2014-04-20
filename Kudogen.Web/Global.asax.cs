using System;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Kudogen.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

#if DEBUG
            // Override SSL cert verification in DEBUG mode
            ServicePointManager.ServerCertificateValidationCallback = (o, cert, chain, errors) => true;
#endif
        }

        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();

            if (ex is HttpException)
                Trace.TraceWarning("Http Error: {0}", ex);

            else
                Trace.TraceError("Application Error: {0}", ex);
        }
    }
}
