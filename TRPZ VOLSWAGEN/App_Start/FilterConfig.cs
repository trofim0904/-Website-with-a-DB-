using System.Web;
using System.Web.Mvc;

namespace TRPZ_VOLSWAGEN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
