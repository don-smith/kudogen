using System.Web.Mvc;

namespace Kudogen.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
#if RELEASE
            filters.Add(new RequireHttpsAttribute());
#endif
            filters.Add(new HandleErrorAttribute());
        }
    }
}
